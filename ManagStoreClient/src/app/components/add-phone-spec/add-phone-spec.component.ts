import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CreatePhoneSpec } from 'src/app/models/phone/createPhoneSpec.';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec, phoneSpecs } from 'src/app/models/phone/phoneSpec';


@Component({
  selector: 'app-add-phone-spec',
  templateUrl: './add-phone-spec.component.html',
  styleUrls: ['./add-phone-spec.component.css']
})
export class AddPhoneSpecComponent {

  @Input() spec!: PhoneSpec
  @Output() stepValidity = new EventEmitter<boolean>(); 
  @Output() selectedSpec = new EventEmitter<PhoneSpec>();




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
 
  selectSpec(phoneSpec: PhoneSpec){
    this.isSpecSelected = true;
    this.spec= phoneSpec;
    this.searchString = phoneSpec.storageGb + 'GB/' + phoneSpec.ramGb + 'GB'
    this.stepValidity.emit(this.isSpecSelected);
    this.selectedSpec.emit(this.spec);
    
  }
  onSearchChange(event: Event){
    this.isSpecSelected = false;
  
   
  }
  cancelSpecCreating(){
    this.isSpecCreating = false
  }
  saveSpec(){
    this.isSpecCreating = false
    // todo save Spec
  }
  createSpec(){
    this.isSpecCreating = true;
     this.searchString=''
  }
}
