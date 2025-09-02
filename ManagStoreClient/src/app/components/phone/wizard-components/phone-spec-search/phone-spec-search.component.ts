import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Input() spec!: PhoneSpec
  @Input() modelId!: number;
  @Output() specSelected = new EventEmitter<PhoneSpec>();
  @Output() createSpecEvent = new EventEmitter();


  searchString: string = '';
  isSpecSelected: boolean = false
  specsDefault: PhoneSpec[] = []



  search$ = new BehaviorSubject<string>("");
  specsFound$: Observable<PhoneSpec[]> = this.search$.pipe(
    debounceTime(300),
    switchMap(search => {
      return this.phoneService.getSpecs(search).pipe(
        catchError(err => {
          console.error(err);
          return of([]);
        })
      );
    })
  );
  


  constructor(private phoneService: PhoneService) {

  }

  ngOnInit() {
    this.search$.subscribe();
    this.getDefaultSpecs();
    this.checkModelSelected();

  }

  getDefaultSpecs(){
    this.phoneService.getSpecsByModelId(this.modelId).subscribe({
      next: (specs: PhoneSpec[]) => {
        this.specsDefault = specs;
      }
    })
  }
  checkModelSelected() {
    if (this.spec.id != 0) {
      this.isSpecSelected = true
    }
  }

  onSelectSpec(phoneSpec: PhoneSpec) {
    this.isSpecSelected = true;
    this.spec = phoneSpec;
    this.specSelected.emit(this.spec);

  }
  onSearchChange(event: Event) {
    this.isSpecSelected = false;


  }

  onCreateSpec() {
    this.createSpecEvent.emit();
  }
  displayValue(): string {
    return this.isSpecSelected && this.spec
      ? `${this.spec.ramGb} GB / ${this.spec.storageGb} GB`
      : this.searchString;
  }
  onInputChange(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.searchString = value;
    console.log('Input value:', JSON.stringify(value));

    this.isSpecSelected = false;
    this.spec = {
      id: 0,
      ramGb: 0,
      storageGb: 0,
      displayIn: 0,
      cameraMp: 0
    };
    this.search$.next(value);

  }

}
