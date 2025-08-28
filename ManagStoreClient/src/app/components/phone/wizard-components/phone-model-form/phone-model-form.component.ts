import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';

@Component({
  selector: 'app-phone-model-form',
  templateUrl: './phone-model-form.component.html',
  styleUrls: ['./phone-model-form.component.css']
})
export class PhoneModelFormComponent {
  @Output() modelCreated = new EventEmitter<PhoneModel>();
  @Output() modelCreatingCanceled = new EventEmitter();

  form!: FormGroup
  manufacturers: IIdName[] = [
    { id: 1, name: 'Apple' },
    { id: 2, name: 'Xiaomi' }
  ]

  isModelSelected: boolean = false;
  createPhoneModel: CreatePhoneModel = {
    manufacturerId: 0,
    name: ''
  };
  constructor(private fb: FormBuilder) { }
  ngOnInit(): void {
    this.form = this.fb.group({
      manufacturerId: [0, [Validators.required, Validators.min(1)]],
      name: ['', [Validators.required, Validators.minLength(1)]]
    });
  }

    onCancelCreating(){
      this.modelCreatingCanceled.emit();
    }
    onSaveModel(){
      if(this.form.valid){
        this.createPhoneModel = this.form.value as CreatePhoneModel;
      //todo: save model 
      const selectedManufacturer = this.manufacturers.find(
        m => m.id == this.createPhoneModel.manufacturerId
      );
      if (!selectedManufacturer) {
        throw new Error('Manufacturer not found');
      }
      let model: PhoneModel = {
        id: 4, // todo from api
        name: this.createPhoneModel.name,
        manufacturerName: selectedManufacturer?.name
      }
      this.modelCreated.emit(model);
    } else  {
      this.form.markAllAsTouched();
    }
    }


  }
