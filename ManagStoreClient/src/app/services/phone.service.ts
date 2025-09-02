import { Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { environment } from '../environments/environment';
import { PhoneModel } from '../models/phone/phoneModel';
import { Observable, retry } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { CreatePhoneModel } from '../models/phone/createPhoneModel';

import { PhoneSpec } from '../models/phone/phoneSpec';

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
}
