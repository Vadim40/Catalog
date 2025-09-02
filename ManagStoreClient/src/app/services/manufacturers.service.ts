import { Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { IIdName } from '../models/IIdName';

@Injectable({
  providedIn: 'root'
})
export class ManufacturersService {

   baseUrl = `${environment.apiUrl}/manufacturers`

   
  constructor(private httpService: HttpService) { 
  }

  getManufacturers() : Observable<IIdName []> {
    return this.httpService.get(this.baseUrl)
  }
}
