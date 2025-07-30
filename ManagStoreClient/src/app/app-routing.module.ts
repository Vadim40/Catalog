import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddItemComponent } from './components/add-item/add-item.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      {path: 'add-item', component: AddItemComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
