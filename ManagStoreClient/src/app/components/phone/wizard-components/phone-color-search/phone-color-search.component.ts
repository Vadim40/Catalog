import { Component, EventEmitter, Input, Output } from '@angular/core';
import { COLORS, Color } from 'src/app/models/color';
import { IMAGES } from 'src/app/models/image';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';

@Component({
  selector: 'app-phone-color-search',
  templateUrl: './phone-color-search.component.html',
  styleUrls: ['./phone-color-search.component.css']
})
export class PhoneColorSearchComponent {
  @Input() variant!: PhoneVariant
  @Output() colorSelected = new EventEmitter<PhoneVariant>();
  @Output() addColorEvent = new EventEmitter();


  searchString?: string;
  isColorSelected: boolean = false;
  colors = COLORS;


  ngOnInit() {
    console.log(this.variant)
    this.updateSearchString();
    this.checkModelSelected();
    
  }

  updateSearchString() {
    if (this.variant) {
      const combined = `${this.variant.color.name}`;
      this.searchString = combined.length > 0 ? combined : undefined;

    }
  }
  checkModelSelected() {
    if (this.variant.color.id != 0) {
      this.isColorSelected = true
    }
  }
  onSearchChange(event: Event) {
    this.isColorSelected = false
  }





  onSelectColor(color: Color) {
    this.searchString = color.name;
    this.variant.images = IMAGES; // todo: load real images
    this.variant.color = color
    this.isColorSelected = true
    this.colorSelected.emit(this.variant);
  }


  onAddColor(){
    this.addColorEvent.emit();
  }
}
