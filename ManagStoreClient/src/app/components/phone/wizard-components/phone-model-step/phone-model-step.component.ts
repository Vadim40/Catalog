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
  @Output() modelSelected = new EventEmitter<PhoneModel>();


  isModelCreating: boolean =false;


  onSaveModel(newModel: PhoneModel){
   
   this.isModelCreating=false;
    this.model=newModel;
    this.stepValidity.emit(true);
    this.modelSelected.emit(this.model);
  }

 
  onModelSelected(selected: PhoneModel) {
    this.model = selected;
    this.modelSelected.emit(this.model);
  }
  onModelCreate(){
    this.isModelCreating = true
  }
  onModelCreatingCancel(){
    this.isModelCreating=false
  }
}
