import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICustomer } from '../models/customer';
import { ICustomerBoxDto } from '../models/customerBox';
import { IResult } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private _http: HttpClient) { }

  getCustomers() : Observable<IResult<ICustomer[]>>{
    return this._http.get<IResult<ICustomer[]>>(`${environment.baseApiUrl}/customers`)
  }

  getCustomerBoxes(customerId: string): Observable<IResult<ICustomerBoxDto[]>>{
    return this._http.get<IResult<ICustomerBoxDto[]>>(`${environment.baseApiUrl}/customers/${customerId}/boxes`)
  }

  addCustomer(firstName: string, lastName: string, phone: string) : Observable<IResult<string>>{
    
    return this._http.post<IResult<string>>(`${environment.baseApiUrl}/customers`, {
      firstName: firstName,
      lastName: lastName,
      phoneNumber: phone
    })
  }

  addBox(customerId: string, label: string, boxTypeId: string, storageAreaId: string) : Observable<IResult<string>>{    
    return this._http.post<IResult<string>>(`${environment.baseApiUrl}/customers/${customerId}/boxes`, {
      customerId: customerId,
      label: label,
      boxTypeId: boxTypeId,
      storageAreaId: storageAreaId
    });
  }

  removeBox(customerId: string, boxId: string) : Observable<IResult<null>>{    
    return this._http.delete<IResult<null>>(`${environment.baseApiUrl}/customers/${customerId}/boxes/${boxId}`);
  }
}

