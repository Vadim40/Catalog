import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormRecord, Validators } from '@angular/forms';
import Decimal from 'decimal.js';
import { PhoneVariantForm } from 'src/app/models/phone/phoneVariantInput';

@Component({
  selector: 'app-add-phone-details',
  templateUrl: './add-phone-details.component.html',
  styleUrls: ['./add-phone-details.component.css']
})
export class AddPhoneDetailsComponent {

  @Input() variant!: PhoneVariantForm;


  form!: FormGroup
 


  imagesUrl: string [] = []

  constructor(
    private fb : FormBuilder,

  ){

  }
  ngOnInit() {
    this.setImages()
    this.form = this.fb.group({
      variantCost : [new Decimal(0), Validators.min(1)]
    })
  }
  setImages(){
    this.imagesUrl = [];
    if(this.variant.apiImages)
    {
      this.variant.apiImages.forEach(i =>
      {
        this.imagesUrl.push(i.url);
      }
      )
    }
    else if(this.variant.images){
      Array.from(this.variant.images).forEach(file => {
        const reader = new FileReader();
        reader.onload = (e: any) => this.imagesUrl.push(e.target.result);
        reader.readAsDataURL(file); 
      });
    }
  }
   validateAndGetData(): any | null {
      if (this.form.invalid) {
        this.form.markAllAsTouched();
        return null;
      }
      return this.form.value; 
    }
}
