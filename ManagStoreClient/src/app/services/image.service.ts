import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor() { }
  
  retriveImageUrls(fileList: FileList): string [] {
    return Array.from(fileList).map(file => URL.createObjectURL(file));
  }
}
