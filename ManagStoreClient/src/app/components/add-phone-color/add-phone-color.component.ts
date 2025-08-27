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
  selector: 'app-add-phone-color',
  templateUrl: './add-phone-color.component.html',
  styleUrls: ['./add-phone-color.component.css']
})
export class AddPhoneColorComponent {

    @Input() variant!: PhoneVariant
    @Output() stepValidity = new EventEmitter<boolean>(); 
    @Output() selectedVariant = new EventEmitter<PhoneVariant>();
  

    
  searchString?: string;
  isVariantSelected: boolean = false;
  colors = COLORS;
 
  selectedColor?: Color;
  newColor?: Color;
  isAddingVariant = false;

  ngOnInit(){
    this.updateSearchString();
    this.checkModelSelected();
  }
  updateSearchString() {
    if (this.variant) {
      const combined = `${this.variant.color.name}`;
      this.searchString = combined.length > 0 ? combined : undefined;

    }
  }
  checkModelSelected(){
    if (this.variant.color.id!= 0) {
      this.isVariantSelected = true
    }
  }
  onSearchChange(event: Event){
    this.selectedColor = undefined
    this.isVariantSelected =false
    console.log(this.searchString && !this.isVariantSelected && !this.isAddingVariant)
  }
    
  

 

  selectVariant(color: Color) {
    this.selectedColor = color;
    this.searchString = color.name;
    this.variant.images = IMAGES; // todo: load real images
    this.variant.color = color
    console.log(this.variant.images)
    this.isVariantSelected =true
    this.selectedVariant.emit(this.variant);
    this.stepValidity.emit(this.isVariantSelected)
  }

  startAddVariant() {
    this.isAddingVariant = true;
    this.searchString = '';
  }

  saveNewVariant(color?: Color, files?: FileList | null) {
    if (!color || !files || files.length === 0) return;

    var newVariant: CreatePhoneModel;

    // Array.from(files).forEach(file => {
    //   const reader = new FileReader();
    //   reader.onload = () => {
    //     newVariant.images.push(reader.result as string);
    //   };
    //   reader.readAsDataURL(file);
    // });

    // this.variants.push(newVariant);
    // this.selectVariant(newVariant);
  }
  cancelAddingVariant() {
    this.isAddingVariant = false;
    this.selectedColor = undefined;   // reset state
    // optionally clear file input as well
  }
  
}
