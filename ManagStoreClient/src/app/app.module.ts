import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AddItemComponent } from './components/add-item/add-item.component';
import { HomeComponent } from './components/home/home.component';
import { AddPhoneComponent } from './components/add-phone/add-phone.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPhoneColorComponent } from './components/add-phone-color/add-phone-color.component';
import { AddItemVariantComponent } from './components/add-item-variant/add-item-variant.component';
import { AddPhoneModelComponent } from './components/phone-model-step/phone-model-step.component';
import { AddPhoneSpecComponent } from './components/add-phone-spec/add-phone-spec.component';
import { AddPhoneVariantWizardComponent } from './components/add-phone-variant-wizard/add-phone-variant-wizard.component';
import { AddPhoneDetailsComponent } from './components/add-phone-details/add-phone-details.component';

import { PhoneModelSearchComponent } from './components/phone-model-search/phone-model-search.component';
import { PhoneModelFormComponent } from './components/phone-model-form/phone-model-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddItemComponent,
    AddPhoneComponent,
    AddPhoneColorComponent,
    AddItemVariantComponent,
    AddPhoneModelComponent,
    AddPhoneSpecComponent,
    AddPhoneVariantWizardComponent,
    AddPhoneDetailsComponent,
    PhoneModelSearchComponent,
    PhoneModelFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
