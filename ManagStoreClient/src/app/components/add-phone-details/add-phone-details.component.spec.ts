import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPhoneDetailsComponent } from './add-phone-details.component';

describe('AddPhoneDetailsComponent', () => {
  let component: AddPhoneDetailsComponent;
  let fixture: ComponentFixture<AddPhoneDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddPhoneDetailsComponent]
    });
    fixture = TestBed.createComponent(AddPhoneDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
