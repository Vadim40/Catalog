import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneModelFormComponent } from './phone-model-form.component';

describe('PhoneModelFormComponent', () => {
  let component: PhoneModelFormComponent;
  let fixture: ComponentFixture<PhoneModelFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PhoneModelFormComponent]
    });
    fixture = TestBed.createComponent(PhoneModelFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
