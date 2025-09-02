import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CreatePhoneSpec } from 'src/app/models/phone/createPhoneSpec.';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec, phoneSpecs } from 'src/app/models/phone/phoneSpec';


@Component({
  selector: 'app-phone-spec-step',
  templateUrl: './phone-spec-step.component.html',
  styleUrls: ['./phone-spec-step.component.css']
})
export class PhoneSpecStepComponent {
  @Input() modelId!: number;
  @Input() spec!: PhoneSpec
  @Output() stepValidity = new EventEmitter<boolean>(); 
  @Output() specSelected = new EventEmitter<PhoneSpec>();




 createSpecObj: CreatePhoneSpec = {
    storageGb: 0,
    ramGb : 0,
    displayIn : 0,
    cameraMp: 0
  }


  searchString?: string;
  isSpecSelected: boolean = false
  isSpecCreating: boolean = false;
  phoneSpecs = phoneSpecs
  

  ngOnInit(){
    this.updateSearchString();
    this.checkModelSelected();
  }
  updateSearchString() {
    if (this.spec) {
    

    }
  }
  checkModelSelected(){
    if (this.spec.id!= 0) {
      this.isSpecSelected = true
    }
  }
 
  onSelectSpec(phoneSpec: PhoneSpec){
    this.isSpecSelected = true;
    this.spec= phoneSpec;
    this.searchString = phoneSpec.storageGb + 'GB/' + phoneSpec.ramGb + 'GB'
    this.stepValidity.emit(this.isSpecSelected);
    this.specSelected.emit(this.spec);
    
  }
  onSearchChange(event: Event){
    this.isSpecSelected = false;
  
   
  }
  onCancelSpecCreating(){
    this.isSpecCreating = false
  }
  onSaveSpec(spec: PhoneSpec){
    this.isSpecCreating = false
    this.specSelected.emit(spec)
    // todo save Spec
  }
  onCreateSpec(){
    this.isSpecCreating = true;
     this.searchString=''
  }
}
