import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Color, COLORS } from 'src/app/models/color';
import { IIdName } from 'src/app/models/IIdName';
import { ApiImage, IMAGES } from 'src/app/models/image';
import { PhoneModelCreate } from 'src/app/models/phone/phoneModelCreate';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariantForm } from 'src/app/models/phone/phoneVariantInput';
import { WizardStep } from 'src/app/models/wizardStep';

@Component({
  selector: 'app-phone-color-step',
  templateUrl: './phone-color-step.component.html',
  styleUrls: ['./phone-color-step.component.css']
})
export class PhoneColorStepComponent {

    @Input() variant!: PhoneVariantForm
    @Output() stepValidity = new EventEmitter<boolean>(); 
    @Output() colorAdded = new EventEmitter<{files: FileList, color: Color}>();
    @Output() colorSelected = new EventEmitter<{files: ApiImage [], color: Color}>();
  

  ngOnInit(){

  }
  isVariantSelected: boolean = false;
  colors = COLORS;
 

  isColorAdding = false;

 

  onSelectColor(event: { files: ApiImage []; color: Color }) {
    this.colorSelected.emit({files: event.files, color: event.color});
    this.stepValidity.emit(true)
  }

  onAddColor() {
    this.isColorAdding = true;
  }

  onSaveColor(event: { files: FileList; color: Color }) {
    this.colorAdded.emit({files: event.files, color: event.color});
    this.isColorAdding = false
    this.stepValidity.emit(true)
  }
  onAddingColorCancel(){
    console.log(this.variant)
    this.isColorAdding = false;
  }
}
