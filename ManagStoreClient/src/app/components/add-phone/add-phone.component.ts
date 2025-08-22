import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Color, COLORS } from 'src/app/models/color';
import { PhoneModel } from 'src/app/models/phone/phoneModel';
import { PhoneSpec } from 'src/app/models/phone/phoneSpec';

@Component({
  selector: 'app-add-phone',
  templateUrl: './add-phone.component.html',
  styleUrls: ['./add-phone.component.css']
})
export class AddPhoneComponent {
 

  isCreatingModel: boolean =false
  searchString?: string;
  selectedModel?: PhoneModel;
  phoneSpecs?: PhoneSpec[]
  selectedSpec?: PhoneSpec;
  selectedColor?: Color;
  phoneColors?: Color[] = COLORS
  dropdownOpen = false;

  phoneModels: PhoneModel[]= [
    {id: 1, manufacturerName: 'Apple', name: "13" },
    {id: 1, manufacturerName: 'Apple', name: "14" },
    {id: 1, manufacturerName: 'Apple', name: "15" },
  ]

   phoneSpecsA: PhoneSpec[][] = [
    // Specs for model "13"
    [
      { id: 1, storageGb: 128, ramGb: 4, displayIn: 6.1, cameraMp: 12 },
      { id: 2, storageGb: 256, ramGb: 4, displayIn: 6.1, cameraMp: 12 }
    ],
    // Specs for model "14"
    [
      { id: 3, storageGb: 128, ramGb: 6, displayIn: 6.1, cameraMp: 12 },
      { id: 4, storageGb: 512, ramGb: 6, displayIn: 6.1, cameraMp: 48 }
    ],
    // Specs for model "15"
    [
      { id: 5, storageGb: 256, ramGb: 8, displayIn: 6.7, cameraMp: 48 }
    ]
  ];
  
  constructor(
    private router: Router,
  )
  {}

  ngOnInit(){

  }


  selectModel(phoneModel: PhoneModel){
    this.selectedModel= phoneModel;
    this.searchString = phoneModel.manufacturerName + ' ' + phoneModel.name
    this.phoneSpecs=this.phoneSpecsA[phoneModel.id]
  }
  onSearchChange(event: Event){
    this.selectedModel= undefined;
    this.phoneSpecs = undefined
    console.log(this.searchString && !this.selectedModel)
    this.selectedSpec=undefined;
  }

 

toggleDropdown() {
  this.dropdownOpen = !this.dropdownOpen;
  console.log(this.selectedModel)
}

selectColor(color: Color) {
  this.selectedColor = color;
  this.dropdownOpen = false;
}
navigateToAddPhoneVariant(){
  this.router.navigate(['/add-phone-variant'])
}
}
