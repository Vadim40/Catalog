import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CreatePhoneSpec } from 'src/app/models/phone/createPhoneSpec.';
import { PhoneSpec, phoneSpecs } from 'src/app/models/phone/phoneSpec';

@Component({
  selector: 'app-phone-spec-search',
  templateUrl: './phone-spec-search.component.html',
  styleUrls: ['./phone-spec-search.component.css']
})
export class PhoneSpecSearchComponent {
  @Input() spec!: PhoneSpec

  @Output() specSelected = new EventEmitter<PhoneSpec>();
  @Output() createSpecEvent = new EventEmitter();


  searchString?: string;
  isSpecSelected: boolean = false
  phoneSpecs = phoneSpecs


  ngOnInit() {
    this.updateSearchString();
    this.checkModelSelected();
  }
  updateSearchString() {
    if (this.spec) {


    }
  }
  checkModelSelected() {
    if (this.spec.id != 0) {
      this.isSpecSelected = true
    }
  }

  onSelectSpec(phoneSpec: PhoneSpec) {
    this.isSpecSelected = true;
    this.spec = phoneSpec;
    this.searchString = phoneSpec.storageGb + 'GB/' + phoneSpec.ramGb + 'GB'
    this.specSelected.emit(this.spec);

  }
  onSearchChange(event: Event) {
    this.isSpecSelected = false;


  }

  onCreateSpec() {
    this.createSpecEvent.emit();
  }
}
