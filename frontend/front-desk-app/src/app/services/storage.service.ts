import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { IResult } from '../models/result';
import { IStorageAreaDto } from '../models/storageAreaDto';
import { IStorageFacility } from '../models/storageFacility';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private _http: HttpClient) { }

  getStorageFacilities() : Observable<IResult<IStorageFacility[]>>{
    return this._http.get<IResult<IStorageFacility[]>>(`${environment.baseApiUrl}/storage-facilities`)
  }

  getStorageAreas(facilityId: number) : Observable<IResult<IStorageAreaDto[]>>{
    return this._http.get<IResult<IStorageAreaDto[]>>(`${environment.baseApiUrl}/storage-facilities/${facilityId}/areas`)
  }
}
