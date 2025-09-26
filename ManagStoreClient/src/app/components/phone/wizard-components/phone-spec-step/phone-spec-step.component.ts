import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PhoneSpecCreate } from 'src/app/models/phone/phoneSpecCreate.';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec, phoneSpecs } from 'src/app/models/phone/phoneSpec';


@Component({
  selector: 'app-phone-spec-step',
  templateUrl: './phone-spec-step.component.html',
  styleUrls: ['./phone-spec-step.component.css']
})
export class PhoneSpecStepComponent {
  @Input() modelId!: number;
  @Input() spec: PhoneSpec | null = null
  @Output() stepValidity = new EventEmitter<boolean>(); 
  @Output() specSelected = new EventEmitter<PhoneSpec>();


  isSpecCreating: boolean = false;

  onSelectSpec(phoneSpec: PhoneSpec | undefined){
    if(phoneSpec){
    this.spec= phoneSpec;
    this.stepValidity.emit(true);
    this.specSelected.emit(this.spec);
  } else {
    this.stepValidity.emit(false)
  }
    
  }

  onCancelSpecCreating(){
    this.isSpecCreating = false
  }
  onSaveSpec(spec: PhoneSpec){
    this.isSpecCreating = false
    this.specSelected.emit(spec)

  }
  onCreateSpec(){
    this.isSpecCreating = true;
  }
}
