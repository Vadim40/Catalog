import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Subject, Observable, startWith, debounceTime, distinctUntilChanged, filter, switchMap, catchError, of, tap, BehaviorSubject } from 'rxjs';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-model-search',
  templateUrl: './phone-model-search.component.html',
  styleUrls: ['./phone-model-search.component.css']
})
export class PhoneModelSearchComponent {

  @Input() model!: PhoneModel
  @Output() modelSelected = new EventEmitter<PhoneModel>();
  @Output() createModelEvent = new EventEmitter();


  searchString: string='';
  isModelSelected: boolean = false;


  phoneModels: PhoneModel[] = []
  createPhoneModel?: CreatePhoneModel;

  

   search$ = new BehaviorSubject<string>("");

  models$: Observable<PhoneModel[]> = this.search$.pipe(
    debounceTime(300),
    distinctUntilChanged((a, b) => a.trim() === b.trim()),
    filter(name => !!name.trim()),
    switchMap(name =>
      this.phoneService.getModels(name).pipe(
        catchError(err => {
          console.error(err);
          return of([]); 
        })
      )
    )
  );

  constructor(
    private phoneService: PhoneService
  ) { }

  ngOnInit() {
    this.checkModelSelected();
  }

  checkModelSelected() {
    if (this.model.id != 0) {
      this.isModelSelected = true
    }
  }
  onSelectModel(phoneModel: PhoneModel) {
    this.isModelSelected = true
  
    this.modelSelected.emit(phoneModel);
   
    
  }
 
  onCreateModel() {
    this.createModelEvent.emit();
  }

  displayValue(): string {
    return this.isModelSelected && this.model
      ? `${this.model.manufacturerName} ${this.model.name}`
      : this.searchString;
  }
  onInputChange(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.searchString = value;
    this.isModelSelected = false; 
    this.model = { id: 0, name: '', manufacturerName: '' };
    this.search$.next(value);
    
  }
  

}
