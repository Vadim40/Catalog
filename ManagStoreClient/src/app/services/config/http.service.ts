import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(protected http: HttpClient) { }

  get<T>(endpoint: string, params?: HttpParams):Observable<T> {
 
    return this.http.get<T>(`${endpoint}`, { params })
  }

  post<T>(endpoint: string, body: any): Observable<T>{
    return this.http.post<T>(`${endpoint}`, body);
  }
  
  put<T>(endpoint: string, body: any) : Observable<T>{
    return this.http.put<T>(`${endpoint}`, body);
  }

  delete<T>(endpoint: string) : Observable<T>{
    return this.http.delete<T>(`${endpoint}`);
  }
}
