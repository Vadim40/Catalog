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
import { UploadImages } from 'src/app/models/uploadImages';
import { ApiImage } from 'src/app/models/image';

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

  variant: PhoneVariant ={
    id: 0,
    color: null,
    model: null,
    spec: null,
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
      modelId: this.variant.model!.id,
      specId: this.variant.spec!.id,
      colorId: this.variant.color!.id,
      cost: this.variant.cost

    }
  
    this.phoneService.addVariant(createVariant).subscribe({
      next: (variantId: number) =>{
        if(this.variant.images){
        const uploadImages : UploadImages ={
          images: this.variant.images,
          variantId: variantId
        }
      
        this.phoneService.addImages(uploadImages).subscribe({})
      }
      }
    })
  }
  onStepValidityChange(isValid: boolean): void {
    if(isValid == false){

    
    this.steps.slice(this.currentStepIndex, this.steps.length).forEach(step =>{
      step.isValid = isValid;
    })
  }
  else{
    this.steps[this.currentStepIndex].isValid = isValid;
  }
  }
  onModelChange(updated: PhoneModel) {
    this.variant.model = updated;
   
  }
  onSpecChange(updated: PhoneSpec){
    this.variant.spec = updated;
  }
  onColorChange(event: {files: ApiImage[] , color: Color}){
    this.variant.color = event.color;
    this.variant.apiImages = event.files;
  
  }
  onVariantColorAdded(event: {files: FileList, color: Color}){
    this.variant.images = event.files;
    this.variant.color = event.color
    this.variant.apiImages = undefined;
  }
  navigateToStep(index: number){
   
    if(this.isStepClickable(index))
    this.currentStepIndex=index;
  }
  isStepClickable(index: number) : boolean{
    return this.steps[index].isValid || (index!=0 && this.steps[index-1].isValid)
  }
}
