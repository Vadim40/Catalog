import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { WizardStep } from 'src/app/models/wizardStep';

@Component({
  selector: 'app-add-phone-variant',
  templateUrl: './add-phone-variant.component.html',
  styleUrls: ['./add-phone-variant.component.css']
})
export class AddPhoneVariantComponent {

    @Input() variant!: PhoneVariant
    @Output() stepValidity = new EventEmitter<boolean>(); 
    @Output() selectedVariant = new EventEmitter<PhoneVariant>();
  
}
