import { Component, EventEmitter, Input, Output } from '@angular/core';
import { COLORS, Color } from 'src/app/models/color';
import { ApiImage, IMAGES } from 'src/app/models/image';
import { PhoneModelCreate } from 'src/app/models/phone/phoneModelCreate';
import { PhoneVariantForm } from 'src/app/models/phone/phoneVariantInput';
import { ColorService } from 'src/app/services/color.service';
import { ImageService } from 'src/app/services/image.service';
import { PhoneService } from 'src/app/services/phone.service';

@Component({
  selector: 'app-phone-color-search',
  templateUrl: './phone-color-search.component.html',
  styleUrls: ['./phone-color-search.component.css']
})
export class PhoneColorSearchComponent {
  @Input() variant!: PhoneVariantForm
  @Output() colorSelected = new EventEmitter<{ files: ApiImage [], color: Color }>();
  @Output() addColorEvent = new EventEmitter();


  colors: Color[] = [];

  imagesUrl: string[] = []

  constructor(
    private colorService: ColorService,
    private phoneService: PhoneService,
    private imageService: ImageService,

  ) {

  }
  ngOnInit() {
    console.log(this.variant)
    this.getModelColors();
    this.setImages()

  }
  setImages() {
    this.imagesUrl = [];
    if (this.variant.apiImages) {
      this.variant.apiImages.forEach(i => {
        this.imagesUrl.push(i.url);
      }
      )
    }
    else if (this.variant.images) {
      this.imagesUrl = this.imageService.retriveImageUrls(this.variant.images)
    }
  }
  getModelColors() {
    this.colorService.getColorsByModelId(this.variant.model!.id).subscribe({
      next: (colors: Color[]) => {
        this.colors = colors
      }
    })
  }

  
  onSelectColor(color: Color) {
    console.log(this.variant)
    console.log(color);
    this.phoneService.getImages(this.variant.model!.id, color.id).subscribe({
      next: (images: ApiImage[]) => {
        this.variant.apiImages = images;
        this.imagesUrl =[]
        images.forEach(i => {
          this.imagesUrl.push(i.url);
        })
        this.variant.color = color

        this.colorSelected.emit({files: this.variant.apiImages, color: this.variant.color});
      }
      
    })

  }
  compareColors(c1: any, c2: any): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  onAddColor() {
    this.addColorEvent.emit();
  }
}
