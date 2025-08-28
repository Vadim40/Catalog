import { Component, EventEmitter, Input, Output } from '@angular/core';
import { COLORS, Color } from 'src/app/models/color';
import { IMAGES } from 'src/app/models/image';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';

@Component({
  selector: 'app-phone-color-add',
  templateUrl: './phone-color-add.component.html',
  styleUrls: ['./phone-color-add.component.css']
})
export class PhoneColorAddComponent {

    @Output() colorAdded = new EventEmitter<PhoneVariant>();
    @Output() colorAddingCanceled = new EventEmitter();

    
  colors = COLORS;
 
  selectedColor?: Color;
  newColor?: Color;



  
  onSaveColor( files?: FileList | null) {
    if ( !files || files.length === 0) return;

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
  onAddingCancel() {
    this.colorAddingCanceled.emit();
       // reset state
    // optionally clear file input as well
  }
  
}
