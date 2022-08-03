import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBoxType } from '../models/boxType';
import { IResult } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class BoxTypesService {

  constructor(private _http: HttpClient) { }

  getList() : Observable<IResult<IBoxType[]>>{
    return this._http.get<IResult<IBoxType[]>>(`${environment.baseApiUrl}/box-types`)
  }
}
