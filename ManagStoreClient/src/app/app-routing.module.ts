import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddItemComponent } from './components/add-item/add-item.component';
import { AddPhoneVariantWizardComponent } from './components/phone/wizard-components/add-phone-variant-wizard/add-phone-variant-wizard.component';


const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      {path: 'add-item', component: AddItemComponent},
      {path: 'add-phone-variant', component: AddPhoneVariantWizardComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
