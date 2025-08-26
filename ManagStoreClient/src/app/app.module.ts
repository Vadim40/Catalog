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
import { AddPhoneModelComponent } from './components/add-phone-model/add-phone-model.component';
import { AddPhoneSpecComponent } from './components/add-phone-spec/add-phone-spec.component';
import { AddPhoneVariantWizardComponent } from './components/add-phone-variant-wizard/add-phone-variant-wizard.component';
import { AddPhoneDetailsComponent } from './components/add-phone-details/add-phone-details.component';

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
    AddPhoneDetailsComponent
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
