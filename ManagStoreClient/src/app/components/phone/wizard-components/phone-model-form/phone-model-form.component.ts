import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IIdName } from 'src/app/models/IIdName';
import { CreatePhoneModel } from 'src/app/models/phone/createPhoneModel';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { ManufacturersService } from 'src/app/services/manufacturers.service';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-model-form',
  templateUrl: './phone-model-form.component.html',
  styleUrls: ['./phone-model-form.component.css']
})
export class PhoneModelFormComponent {
  @Output() modelCreated = new EventEmitter<PhoneModel>();
  @Output() modelCreatingCanceled = new EventEmitter();

  form!: FormGroup
  manufacturers: IIdName[] = [];

  isModelSelected: boolean = false;
  createPhoneModel: CreatePhoneModel = {
    manufacturerId: 0,
    name: ''
  };

  model: PhoneModel = {
    id: 0,
    name:'',
    manufacturerName:''
  }
  constructor(
    private fb: FormBuilder,
    private manufacturersService: ManufacturersService,
    private phoneService: PhoneService,
  ) { }
  ngOnInit(): void {
    this.form = this.fb.group({
      manufacturerId: [0, [Validators.required, Validators.min(1)]],
      name: ['', [Validators.required, Validators.minLength(1)]]
    });
    this.getManufacturers()
  }


  getManufacturers() {
    this.manufacturersService.getManufacturers().subscribe({
      next: (manufacturers: IIdName []) =>{
          this.manufacturers= manufacturers;
      }
    })
  }
  onCancelCreating() {
    this.modelCreatingCanceled.emit();
  }

  onSaveModel() {
    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }
  
    this.prepareModelFromForm();
    this.sendCreateRequest();
  }
  
  private prepareModelFromForm(): void {
    this.createPhoneModel = this.form.value as CreatePhoneModel;
    const selectedManufacturer = this.manufacturers.find(
      m => m.id === this.createPhoneModel.manufacturerId
    );
    if (!selectedManufacturer) throw new Error('Manufacturer not found');
  
    this.model.name = this.createPhoneModel.name;
    this.model.manufacturerName = selectedManufacturer.name;
  }
  
  private sendCreateRequest(): void {
    this.phoneService.createModel(this.createPhoneModel).subscribe({
      next: id => {
        this.model.id = id;
        this.modelCreated.emit(this.model);
      },
      error: err => console.error(err)
    });
  }
  
}
