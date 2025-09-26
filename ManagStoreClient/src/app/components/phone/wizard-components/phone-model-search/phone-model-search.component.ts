import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subject, Observable, startWith, debounceTime, distinctUntilChanged, filter, switchMap, catchError, of, tap, BehaviorSubject } from 'rxjs';
import { IIdName } from 'src/app/models/IIdName';
import { PhoneModelCreate } from 'src/app/models/phone/phoneModelCreate';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-model-search',
  templateUrl: './phone-model-search.component.html',
  styleUrls: ['./phone-model-search.component.css']
})
export class PhoneModelSearchComponent {

  @Input() model: PhoneModel | null = null;
  @Output() modelSelected = new EventEmitter<PhoneModel | null>();
  @Output() createModelEvent = new EventEmitter();


  phoneModels: PhoneModel[] = []
  createPhoneModel?: PhoneModelCreate;



  searchCtrl = new FormControl;

  models$?: Observable<PhoneModel[]> ;

  constructor(
    private phoneService: PhoneService
  ) { }

  ngOnInit() {
   this.models$ = this.searchCtrl.valueChanges.pipe(
      debounceTime(300),
      filter(val => typeof val === 'string' && !!val.trim() ),
      distinctUntilChanged((a, b) => a.trim() === b.trim()),
      tap(()=>{
        this.model =null
        this.modelSelected.emit(null);
      }),
      switchMap(name =>
    
        this.phoneService.getModels(name).pipe(
          catchError(err => {
            console.error(err);
            return of([]);
          })
        )
        
      )
    );
    
    this.searchCtrl.setValue(this.displayValue(), { emitEvent: false });
  }


  onSelectModel(phoneModel: PhoneModel) {
    this.modelSelected.emit(phoneModel);
    this.model = phoneModel;
    this.searchCtrl.setValue(this.displayValue(), { emitEvent: false });

  }

  onCreateModel() {
    this.createModelEvent.emit();
  }

  displayValue(): string {
    return this.model
      ? `${this.model.manufacturerName} ${this.model.name}`
      : '';
  }



}
