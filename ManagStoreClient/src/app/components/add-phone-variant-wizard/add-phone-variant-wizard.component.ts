import { Component } from '@angular/core';
import Decimal from 'decimal.js';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { Color } from 'src/app/models/color';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { WizardStep } from 'src/app/models/wizardStep';

@Component({
  selector: 'app-add-phone-variant-wizard',
  templateUrl: './add-phone-variant-wizard.component.html',
  styleUrls: ['./add-phone-variant-wizard.component.css']
})
export class AddPhoneVariantWizardComponent {
  steps: WizardStep[] = [
    { id: 'modelSelect', label: 'Select model', isValid: false },
    { id: 'specSelect', label: ' Selec specification', isValid: false },
    {id: 'variantSelect', label: 'Select variant', isValid: false}

  ];
  currentStepIndex = 0;

  model: PhoneModel = {
    id: 0,
    name: "",
    manufacturerName: ""
  }
  spec: PhoneSpec = {
    id: 0,
    storageGb: 0,
    ramGb: 0,
    displayIn: 0,
    cameraMp: 0
  }
  variant: PhoneVariant ={
    id: 0,
    modelId: 0,
    specId: 0,
    color : {
      id: 0,
      name: '',
      hex: ''
    },
    cost: new Decimal(0),
    images : []
  }
  get isLastStep(): boolean {
    return this.currentStepIndex === this.steps.length - 1;
  }

  get isFirstStep(): boolean {
    return this.currentStepIndex === 0;
  }

  nextStep(): void {
    if (this.steps[this.currentStepIndex].isValid) {
      this.currentStepIndex++;
    }
  }

  previousStep(): void {
    if (this.currentStepIndex > 0) {
      this.currentStepIndex--;
    }
  }
  onSubmit(): void {

    alert('Profile submitted successfully!');
  }
  onStepValidityChange(isValid: boolean): void {
    this.steps[this.currentStepIndex].isValid = isValid;
  }
  onModelChange(updated: PhoneModel) {
    this.model = updated;
  }
  onSpecChange(updated: PhoneSpec){
    this.spec = updated;
  }
  onVariantChange(updated: PhoneVariant){
    this.variant = updated;
  }
  navigateToStep(index: number){
   
    if(this.isStepClickable(index))
    this.currentStepIndex=index;
  }
  isStepClickable(index: number) : boolean{
    return this.steps[index].isValid || (index!=0 && this.steps[index-1].isValid)
  }
}
