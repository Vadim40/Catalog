import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { BehaviorSubject, Observable, debounceTime, distinctUntilChanged, filter, switchMap, catchError, of, tap } from 'rxjs';
import { COLORS, Color } from 'src/app/models/color';
import { IMAGES } from 'src/app/models/image';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { ColorService } from 'src/app/services/color.service';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-phone-color-add',
  templateUrl: './phone-color-add.component.html',
  styleUrls: ['./phone-color-add.component.css']
})
export class PhoneColorAddComponent {

  @Output() colorAdded = new EventEmitter<{ files: FileList, color: Color }>();
  @Output() colorAddingCanceled = new EventEmitter();

  selectedColor?: Color;

  searchCtrl = new FormControl;
  colors$?: Observable<Color[]> ;

  imagesUrl: string[] = []
  fileList?: FileList;
  form!: FormGroup

  constructor(
    private colorService: ColorService,
    private imageService: ImageService,
    private fb: FormBuilder,

  ) {

  }
  ngOnInit() {
    this.colors$= this.searchCtrl.valueChanges.pipe(
      debounceTime(300),
      filter(val => typeof val === "string" && !!val.trim()),
      distinctUntilChanged((a, b) => a.trim() === b.trim()), 
      tap(()=>{
        this.selectedColor= undefined;
        this.form.get('isColorSelected')?.setValue(false);
      }),
      switchMap(name =>
        this.colorService.getColors(name).pipe(
          catchError(err => {
            console.error(err);
            return of([]);
          })
        )
      )
    );
    this.form = this.fb.group({
      isColorSelected: [false, Validators.requiredTrue],
      imagesUrl: [[], this.arrayNotEmpty]
    });

  }
  arrayNotEmpty(control: AbstractControl): ValidationErrors | null {
    return Array.isArray(control.value) && control.value.length > 0
      ? null
      : { arrayNotEmpty: true };
  }
  onSaveColor() {
    console.log(this.form)
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.colorAdded.emit({ files: this.fileList!, color: this.selectedColor! });

  }
  onAddingCancel() {
    this.colorAddingCanceled.emit();

  }


  onFilesSelected(files: FileList | null) {
    if (files) {
      this.imagesUrl = this.imageService.retriveImageUrls(files)
      this.fileList = files;
      this.form.get('imagesUrl')?.setValue(this.imagesUrl);
      this.form.get('imagesUrl')?.updateValueAndValidity();
    }

  }


 
  onSelectColor(color: Color) {
    this.selectedColor = color;
    this.searchCtrl.setValue(this.displayValue(), {emitEvent: false})
    this.form.get('isColorSelected')?.setValue(true);

  }
  displayValue(): string {
    return this.selectedColor
      ? `${this.selectedColor.name}`
      : '';
  }


}
