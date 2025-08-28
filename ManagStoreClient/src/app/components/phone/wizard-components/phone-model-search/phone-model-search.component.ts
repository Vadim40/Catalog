import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';

@Component({
  selector: 'app-phone-model-search',
  templateUrl: './phone-model-search.component.html',
  styleUrls: ['./phone-model-search.component.css']
})
export class PhoneModelSearchComponent {

    @Input() model!: PhoneModel
    @Output() modelSelected = new EventEmitter<PhoneModel>();
    @Output() createModelEvent=new EventEmitter();
    
 manufacturers: IIdName [] = [
    {id:1, name: 'Apple'},
    {id:2, name: 'Xiaomi'}
  ]
  searchString?: string ;
  isModelSelected: boolean = false;

  
  phoneModels: PhoneModel[]= [
    {id: 1, manufacturerName: 'Apple', name: "13" },
    {id: 2, manufacturerName: 'Apple', name: "14" },
    {id: 3, manufacturerName: 'Apple', name: "15" },
  ]
  
  createPhoneModel?: CreatePhoneModel; 
  ngOnInit(){

    this.updateSearchString();
    this.checkModelSelected();
  }
  updateSearchString() {
    if (this.model) {
      const combined = `${this.model.manufacturerName} ${this.model.name}`.trim();
      this.searchString = combined.length > 0 ? combined : undefined;

    }
  }
  checkModelSelected(){
    if (this.model.id!= 0) {
      this.isModelSelected = true
    }
  }
  onSelectModel(phoneModel: PhoneModel){
    this.isModelSelected = true
    this.searchString = phoneModel.manufacturerName + ' ' + phoneModel.name
    this.modelSelected.emit(phoneModel);
    
  }
  onSearchChange(event: Event){
    this.isModelSelected= false
  }
  onCreateModel(){
    this.createModelEvent.emit();
  }
 

}
