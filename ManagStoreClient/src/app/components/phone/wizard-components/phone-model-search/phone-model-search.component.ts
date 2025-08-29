import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Subject, Observable, startWith, debounceTime, distinctUntilChanged, filter, switchMap, catchError, of, tap } from 'rxjs';
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

  manufacturers: IIdName[] = [
    { id: 1, name: 'Apple' },
    { id: 2, name: 'Xiaomi' }
  ]
  searchString: string='';
  isModelSelected: boolean = false;


  phoneModels: PhoneModel[] = []
  createPhoneModel?: CreatePhoneModel;



  search$ = new Subject<string>();

  phoneModels$: Observable<PhoneModel[]> = this.search$.pipe(
    tap(() => this.isModelSelected = false), 
    debounceTime(300),
    distinctUntilChanged(),
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

    this.updateSearchString();
    this.checkModelSelected();
  }
  updateSearchString() {
    if (this.model) {
      const combined = `${this.model.manufacturerName} ${this.model.name}`.trim();
   
    }
  }
  checkModelSelected() {
    if (this.model.id != 0) {
      this.isModelSelected = true
    }
  }
  onSelectModel(phoneModel: PhoneModel) {
    this.isModelSelected = true
    this.searchString = phoneModel.manufacturerName + ' ' + phoneModel.name
    this.modelSelected.emit(phoneModel);

  }
 
  onCreateModel() {
    this.createModelEvent.emit();
  }


}
