import { Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { environment } from '../environments/environment';
import { PhoneModel } from '../models/phone/phoneModel';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { CreatePhoneModel } from '../models/phone/createPhoneModel';
import { IIdName } from '../models/IIdName';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  baseUrl = `${environment.apiUrl}/phones`
  constructor(
    private httpService: HttpService
  ) { }


  getModels(name: string) : Observable<PhoneModel []>{
    const endpoint = "models"
    const params = new HttpParams().set('name', name);
     return this.httpService.get<PhoneModel[]>(`${this.baseUrl}/${endpoint}`, params)
  }
  createModel(model: CreatePhoneModel) : Observable<number>{
    const endpoint = "models"
     return this.httpService.post<number>(`${this.baseUrl}/${endpoint}`, model)
  }
  
  getManufacturers() : Observable<IIdName> {
    const endpoint = 
  }
}
