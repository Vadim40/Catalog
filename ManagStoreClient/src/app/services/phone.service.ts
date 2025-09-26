import { Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { environment } from '../environments/environment';
import { PhoneModel } from '../models/phone/phoneModel';
import { Observable, retry } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { PhoneModelCreate } from '../models/phone/phoneModelCreate';

import { PhoneSpec } from '../models/phone/phoneSpec';
import { ImagesUpload } from '../models/imagesUpload';
import { ApiImage } from '../models/image';
import { PhoneVariantCreate } from '../models/phone/phoneVariantCreate';
import { PhoneVariant } from '../models/phone/phoneVariant';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  baseUrl = `${environment.apiUrl}/phones`
  constructor(
    private httpService: HttpService
  ) { }


  getModels(name: string): Observable<PhoneModel[]> {
    const endpoint = `${this.baseUrl}/models`
    const params = new HttpParams().set('name', name);
    return this.httpService.get<PhoneModel[]>(endpoint, params)
  }
  createModel(model: PhoneModelCreate): Observable<number> {
    const endpoint = `${this.baseUrl}/models`
    return this.httpService.post<number>(endpoint, model)
  }

  getSpecs(search: string): Observable<PhoneSpec[]> {
    const endpoint = `${this.baseUrl}/specs`
    const params = new HttpParams().set('search', search);
    return this.httpService.get<PhoneSpec[]>(endpoint, params);
  }
  getSpecsByModelId(modelId: number): Observable<PhoneSpec[]> {
    const endpoint = `${this.baseUrl}/${modelId}/specs`
    return this.httpService.get<PhoneSpec[]>(endpoint);
  }

  addSpec(specCreate: PhoneModelCreate): Observable<number> {
    const endpoint = `${this.baseUrl}/specs`
    return this.httpService.post<number>(endpoint, specCreate);
  }
  addImages(uploadImages: ImagesUpload): Observable<void> {
    const endpoint = `${this.baseUrl}/images`
    const formData = new FormData;
    Array.from(uploadImages.images).forEach(image => {
      formData.append('images', image);
    })
    formData.append('variantId', uploadImages.variantId.toString())
    return this.httpService.post(endpoint, formData)
  }
  getImages(modelId: number, colorId: number): Observable<ApiImage[]> {
    const endpoint = `${this.baseUrl}/images`
    const params = new HttpParams()
      .set("modelId", modelId.toString())
      .set("colorId", colorId.toString());
    return this.httpService.get<ApiImage[]>(endpoint, params);
  }
  addVariant(createVariant: PhoneVariantCreate): Observable<number> {
    const endpoint = `${this.baseUrl}/variants`
    return this.httpService.post<number>(endpoint, createVariant);
  }
  searchVariant(name: string): Observable<PhoneVariant[]> {
    const endpoint = `${this.baseUrl}/variants`
    const params = new HttpParams().set("name", name);
    return this.httpService.get<PhoneVariant[]>(endpoint, params)
  }
}
