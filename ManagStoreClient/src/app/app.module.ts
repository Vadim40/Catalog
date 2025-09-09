import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AddItemComponent } from './components/add-item/add-item.component';
import { HomeComponent } from './components/home/home.component';
import { AddPhoneComponent } from './components/add-phone/add-phone.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddItemVariantComponent } from './components/add-item-variant/add-item-variant.component';
import { AddPhoneDetailsComponent } from './components/phone/wizard-components/add-phone-details/add-phone-details.component';
import { AddPhoneVariantWizardComponent } from './components/phone/wizard-components/add-phone-variant-wizard/add-phone-variant-wizard.component';
import { PhoneColorStepComponent } from './components/phone/wizard-components/phone-color-step/phone-color-step.component';
import { PhoneModelFormComponent } from './components/phone/wizard-components/phone-model-form/phone-model-form.component';
import { PhoneModelSearchComponent } from './components/phone/wizard-components/phone-model-search/phone-model-search.component';
import { PhoneModelStepComponent } from './components/phone/wizard-components/phone-model-step/phone-model-step.component';
import { PhoneSpecFormComponent } from './components/phone/wizard-components/phone-spec-form/phone-spec-form.component';
import { PhoneSpecSearchComponent } from './components/phone/wizard-components/phone-spec-search/phone-spec-search.component';
import { PhoneSpecStepComponent } from './components/phone/wizard-components/phone-spec-step/phone-spec-step.component';
import { PhoneColorSearchComponent } from './components/phone/wizard-components/phone-color-search/phone-color-search.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { PhoneColorAddComponent } from './components/phone/wizard-components/phone-color-add/phone-color-add.component';
import { GlobalErrorInterceptor } from './interceptors/global-error.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddItemComponent,
    AddPhoneComponent,
    PhoneColorStepComponent,
    AddItemVariantComponent,
    PhoneModelStepComponent,
    PhoneSpecStepComponent,
    AddPhoneVariantWizardComponent,
    AddPhoneDetailsComponent,
    PhoneModelSearchComponent,
    PhoneModelFormComponent,
    PhoneSpecSearchComponent,
    PhoneSpecFormComponent,
    PhoneColorSearchComponent,
    PhoneModelFormComponent,
    PhoneColorAddComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: GlobalErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
