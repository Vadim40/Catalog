import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';

@Component({
  selector: 'app-add-phone-details',
  templateUrl: './add-phone-details.component.html',
  styleUrls: ['./add-phone-details.component.css']
})
export class AddPhoneDetailsComponent {

  @Input() model!: PhoneModel;
  @Input() spec!: PhoneSpec;
  @Input() variant!: PhoneVariant;
  @Output() selectedVariant = new EventEmitter<PhoneVariant>();
}
