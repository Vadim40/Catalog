import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';

@Component({
  selector: 'app-phone-model-form',
  templateUrl: './phone-model-form.component.html',
  styleUrls: ['./phone-model-form.component.css']
})
export class PhoneModelFormComponent {
  @Input() model!: PhoneModel
    @Output() stepValidity = new EventEmitter<boolean>(); 
    @Output() selectedModel = new EventEmitter<PhoneModel>();
    @Output() saveModelEvent = new EventEmitter<PhoneModel>();
    @Output() cancelCreateModel = new EventEmitter();

    
 manufacturers: IIdName [] = [
    {id:1, name: 'Apple'},
    {id:2, name: 'Xiaomi'}
  ]
  searchString?: string ;
  isModelSelected: boolean = false;

  

  createPhoneModel?: CreatePhoneModel; 
  ngOnInit(){
   
  }


  onManufacturerChange(event: Event){

  }
  cancelCreating(){
    this.cancelCreateModel.emit();
  }
  saveModel(){
    let model : PhoneModel = {
      id: 1,
      name: ' no',
      manufacturerName: 'ap'
    }
    this.saveModelEvent.emit(model);

  }

 
}
