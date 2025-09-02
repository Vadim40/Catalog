import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CreatePhoneSpec } from 'src/app/models/phone/createPhoneSpec.';
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
  createSpec?: CreatePhoneSpec
  ngOnInit(): void {
    this.form = this.fb.group({
      storageGb: [this.createSpec?.storageGb || 0, [Validators.required, Validators.min(1)]],
      ramGb: [this.createSpec?.ramGb || 0, [Validators.required, Validators.min(1)]],
      displayIn: [this.createSpec?.displayIn || 0, [Validators.required, Validators.min(1)]],
      cameraMp: [this.createSpec?.cameraMp || 0, [Validators.required, Validators.min(1)]]
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
