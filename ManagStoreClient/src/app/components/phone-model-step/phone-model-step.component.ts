import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';

@Component({
  selector: 'app-phone-model-step',
  templateUrl: './phone-model-step.component.html',
  styleUrls: ['./phone-model-step.component.css']
})

export class AddPhoneModelComponent {
  @Input() model!: PhoneModel
  @Output() stepValidity = new EventEmitter<boolean>(); 
  @Output() selectedModel = new EventEmitter<PhoneModel>();

  
  creteaModel: CreatePhoneModel = {
    manufacturerId : 0,
    name : ""
  }
 
  manufacturers: IIdName [] = [
    {id:1, name: 'Apple'},
    {id:2, name: 'Xiaomi'}
  ]
  searchString?: string ;
  isModelSelected: boolean = false;
  isModelCreating: boolean = false;
  
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
  selectModel(phoneModel: PhoneModel){
    this.isModelSelected = true
    this.model= phoneModel;
    this.searchString = phoneModel.manufacturerName + ' ' + phoneModel.name
    
    this.stepValidity.emit(this.isModelSelected);
    this.selectedModel.emit(this.model);
    
  }
  onSearchChange(event: Event){
    this.isModelSelected= false
  
    console.log(this.searchString && !this.isModelSelected)
    console.log(this.phoneModels)
  }
  onManufacturerChange(event: Event){
   
  }
  cancelCreating(){
    this.isModelCreating = false
  }
  saveModel(newModel: PhoneModel){
    this.updateSearchString();
   this.isModelCreating=false;
    this.isModelSelected = true

    this.model=newModel;
    this.stepValidity.emit(this.isModelSelected);
    this.selectedModel.emit(this.model);
  }
  createModel(){
    this.isModelCreating = true;
    this.searchString=''
    
  }
 
  onModelChange(selected: PhoneModel) {
    this.model = selected;
   
  }

}
