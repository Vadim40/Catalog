import { Component, ViewChild } from '@angular/core';
import Decimal from 'decimal.js';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { Color } from 'src/app/models/color';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneVariant } from 'src/app/models/phone/phoneVariant';
import { WizardStep } from 'src/app/models/wizardStep';
import { AddPhoneDetailsComponent } from '../add-phone-details/add-phone-details.component';
import { PhoneService } from 'src/app/services/phone.service';
import { CreatePhoneVariant } from 'src/app/models/phone/createPhonVariant';

@Component({
  selector: 'app-add-phone-variant-wizard',
  templateUrl: './add-phone-variant-wizard.component.html',
  styleUrls: ['./add-phone-variant-wizard.component.css']
})
export class AddPhoneVariantWizardComponent {

  @ViewChild(AddPhoneDetailsComponent)
  step4Component!: AddPhoneDetailsComponent;

  steps: WizardStep[] = [
    { id: 'modelSelect', label: 'Select model', isValid: false }, 
    { id: 'specSelect', label: ' Selec specification', isValid: false},
    {id: 'variantSelect', label: 'Select color', isValid: false},
    {id: 'confirmDetalis', label: 'Confirm detalis', isValid:true}

  ];

  currentStepIndex = 0;

  model: PhoneModel = {
    id: 0,
    name: "",
    manufacturerName: ""
  }
  spec: PhoneSpec | null = null;
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
  }


  constructor(
    private phoneService: PhoneService,
  ) {

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

    const step4Data = this.step4Component.validateAndGetData();
    if (!step4Data) {
      return; 
    }
  
  
    this.variant.cost = step4Data.variantCost
    let createVariant : CreatePhoneVariant = {
      modelId: this.variant.modelId,
      specId: this.variant.specId,
      colorId: this.variant.color.id,
      cost: this.variant.cost

    }
    console.log(this.variant)
    this.phoneService.addVariant(createVariant).subscribe({
      next: (variantId: number) =>{
        console.log(variantId);
      }
    })
  }
  onStepValidityChange(isValid: boolean): void {
    this.steps[this.currentStepIndex].isValid = isValid;
  }
  onModelChange(updated: PhoneModel) {
    this.model = updated;
    this.variant.modelId = updated.id
   
  }
  onSpecChange(updated: PhoneSpec){
    this.spec = updated;
    this.variant.specId = updated.id
  }
  onVariantChange(updated: PhoneVariant){
    this.variant = updated;
  }
  onVariantColorAdded(event: {files: FileList, color: Color}){
    this.variant.images = event.files;
    this.variant.color = event.color
  }
  navigateToStep(index: number){
   
    if(this.isStepClickable(index))
    this.currentStepIndex=index;
  }
  isStepClickable(index: number) : boolean{
    return this.steps[index].isValid || (index!=0 && this.steps[index-1].isValid)
  }
}
