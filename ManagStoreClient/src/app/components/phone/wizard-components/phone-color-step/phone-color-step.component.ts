import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Color, COLORS } from 'src/app/models/color';
import { IIdName } from 'src/app/models/IIdName';
import { IMAGES } from 'src/app/models/image';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { WizardStep } from 'src/app/models/wizardStep';

@Component({
  selector: 'app-phone-color-step',
  templateUrl: './phone-color-step.component.html',
  styleUrls: ['./phone-color-step.component.css']
})
export class AddPhoneColorComponent {

    @Input() variant!: PhoneVariant
    @Output() stepValidity = new EventEmitter<boolean>(); 
    @Output() colorSelected = new EventEmitter<PhoneVariant>();
  

    
  isVariantSelected: boolean = false;
  colors = COLORS;
 

  isColorAdding = false;

 

  onSelectColor(variant: PhoneVariant) {
   this.colorSelected.emit(variant);
  }

  onAddColor() {
    this.isColorAdding = true;
  }

  onSaveColor(variant: PhoneVariant){
    this.colorSelected.emit(variant);
  }
  onAddingColorCancel(){
    this.isColorAdding = false;
  }
}
