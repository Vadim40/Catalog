import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subject, Observable, debounceTime, distinctUntilChanged, filter, switchMap, catchError, of, tap, BehaviorSubject } from 'rxjs';
import { CreatePhoneSpec } from 'src/app/models/phone/createPhoneSpec.';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec, phoneSpecs } from 'src/app/models/phone/phoneSpec';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-spec-search',
  templateUrl: './phone-spec-search.component.html',
  styleUrls: ['./phone-spec-search.component.css']
})
export class PhoneSpecSearchComponent {
  @Input() spec: PhoneSpec | null = null;
  @Input() modelId!: number;
  @Output() specSelected = new EventEmitter<PhoneSpec | undefined>();
  @Output() createSpecEvent = new EventEmitter();


  searchCtrl = new FormControl;

  specsDefault: PhoneSpec[] = []
  specsFound$?: Observable<PhoneSpec[]>

  regex =  /^\s*\d+\s*(\/\s*\d+)?\s*$/
  
 



  constructor(private phoneService: PhoneService) {

  }

  ngOnInit() {

    this.specsFound$= this.searchCtrl.valueChanges.pipe(
      debounceTime(300),
      filter(val => typeof val === 'string' && !!val.trim() ),
      distinctUntilChanged((a, b) => a.trim() === b.trim()),
      tap(()=>{
        this.spec =null
      }),
      switchMap(search => {
        if (this.regex.test(search)) {
          return this.phoneService.getSpecs(search).pipe(
            catchError(err => {
              console.error(err);
              return of([]);
            })
          );
        }
        else {
          return of([]);
        }
      })
    );
    this.getDefaultSpecs();
   
    this.searchCtrl.setValue(this.displayValue(), {emitEvent: false})

  }

  getDefaultSpecs() {
    this.phoneService.getSpecsByModelId(this.modelId).subscribe({
      next: (specs: PhoneSpec[]) => {
        this.specsDefault = specs;
      }
    })
  }


  onSelectSpec(phoneSpec: PhoneSpec) {
    this.spec = phoneSpec;
    this.searchCtrl.setValue(this.displayValue(), {emitEvent: false})
    this.specSelected.emit(this.spec);

  }

  onCreateSpec() {
    this.createSpecEvent.emit();
  }
  displayValue(): string {
    return  this.spec
      ? `${this.spec.ramGb} / ${this.spec.storageGb}`
      : '';
  }


}
