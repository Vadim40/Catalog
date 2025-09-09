import { Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { environment } from '../environments/environment';
import { PhoneModel } from '../models/phone/phoneModel';
import { Observable, retry } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { CreatePhoneModel } from '../models/phone/createPhoneModel';

import { PhoneSpec } from '../models/phone/phoneSpec';
import { UploadImages } from '../models/uploadImages';
import { ApiImage } from '../models/image';
import { CreatePhoneVariant } from '../models/phone/createPhonVariant';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  baseUrl = `${environment.apiUrl}/phones`
  constructor(
    private httpService: HttpService
  ) { }


  getModels(name: string) : Observable<PhoneModel []>{
    const endpoint = `${this.baseUrl}/models`
    const params = new HttpParams().set('name', name);
     return this.httpService.get<PhoneModel[]>(endpoint, params)
  }
  createModel(model: CreatePhoneModel) : Observable<number>{
    const endpoint = `${this.baseUrl}/models`
     return this.httpService.post<number>(endpoint, model)
  }
  
  getSpecs(search: string) : Observable<PhoneSpec []> {
    const endpoint =`${this.baseUrl}/specs`
    const params = new HttpParams().set('search', search);
    return this.httpService.get<PhoneSpec []>(endpoint,params);
  }
  getSpecsByModelId(modelId: number) : Observable<PhoneSpec []> {
    const endpoint =`${this.baseUrl}/${modelId}/specs`
    return this.httpService.get<PhoneSpec []>(endpoint);
  }
  
  addSpec(specCreate: CreatePhoneModel) : Observable<number> {
      const endpoint =`${this.baseUrl}/specs`
      return this.httpService.post<number>(endpoint, specCreate);
  }
  addImages(uploadImages: UploadImages) : Observable<void>{
    const endpoint  =`${this.baseUrl}/images`
    const formData = new FormData;
    Array.from(uploadImages.images).forEach( image =>{
      formData.append('uploadImages',image);
    })
    return this.httpService.post(endpoint, formData)
  }
  getImages(modelId: number, colorId: number) : Observable<ApiImage []>{
     const endpoint  =`${this.baseUrl}/images`
     const params = new HttpParams;
     params.set("modelId", modelId)
     params.set("colorId", colorId);
     return this.httpService.get<ApiImage []>(endpoint, params);
  }
  addVariant(createVariant: CreatePhoneVariant) : Observable<number> {
      const endpoint  =`${this.baseUrl}/variants`
      return this.httpService.post<number>(endpoint, createVariant);
  }
}
