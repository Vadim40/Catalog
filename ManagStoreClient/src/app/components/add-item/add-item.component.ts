import { Component } from '@angular/core';
import { Category } from 'src/app/models/category';
import { IIdName } from 'src/app/models/IIdName';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent {

  selectedCategory : number =0;

  categories: IIdName[] = [ 
    {id: 1, name: 'phone'},
    {id: 2, name: 'headphones'}
  ]
  category =Category;
}
