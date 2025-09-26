import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import Decimal from 'decimal.js';
import { PhoneSpecCreate } from 'src/app/models/phone/phoneSpecCreate.';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-spec-form',
  templateUrl: './phone-spec-form.component.html',
  styleUrls: ['./phone-spec-form.component.css']
})
export class PhoneSpecFormComponent {

  @Output() specCreated = new EventEmitter<PhoneSpec>();
  @Output() specCreatingCanceled = new EventEmitter<void>();

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private phoneService: PhoneService,

  ) { }
  createSpec: PhoneSpecCreate ={
    storageGb : 0,
    ramGb: 0,
    cameraMp: 0,
    displayIn: new Decimal(0)
  }
  ngOnInit(): void {
    this.form = this.fb.group({
      storageGb: [this.createSpec.storageGb, [Validators.required, Validators.min(1)]],
      ramGb: [this.createSpec.ramGb, [Validators.required, Validators.min(1)]],
      displayIn: [this.createSpec.displayIn, [Validators.required, Validators.min(1)]],
      cameraMp: [this.createSpec.cameraMp, [Validators.required, Validators.min(1)]]
    });
  }

  onSave() {
    if (this.form.valid) {
       let spec= this.form.value as PhoneSpec;
      this.phoneService.addSpec(this.form.value).subscribe({
        next: (id: number) =>{
          spec.id = id;
          this.specCreated.emit(spec);
        }
      })
     
    }
  }

  onCancel() {
    this.specCreatingCanceled.emit();
  }
}
