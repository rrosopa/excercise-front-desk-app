import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICustomer } from '../models/customer';
import { IResult } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private _http: HttpClient) { }

  getList() : Observable<IResult<ICustomer[]>>{
    return this._http.get<IResult<ICustomer[]>>(`${environment.baseApiUrl}/customers`)
  }

  add(firstName: string, lastName: string, phone: string) : Observable<IResult<string>>{
    
    return this._http.post<IResult<string>>(`${environment.baseApiUrl}/customers`, {
      firstName: firstName,
      lastName: lastName,
      phoneNumber: phone
    })
  }
}
