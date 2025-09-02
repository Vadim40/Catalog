import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpService } from './config/http.service';
import { Observable } from 'rxjs';
import { Color } from '../models/color';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

 
    baseUrl = `${environment.apiUrl}/colors`

   constructor(private httpService: HttpService) { 
   }
 
   getColorsByModelId(modelId: number): Observable<Color []> {
    const endpoint = `${this.baseUrl}/${modelId}`;
    return this.httpService.get<Color []>(endpoint);
   }
   getColors(search: string): Observable<Color []> {
    const endpoint = `${this.baseUrl}`;
    const params = new HttpParams().set('search', search);
    return this.httpService.get<Color []>(endpoint, params);
   }
}
