import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private _http: HttpClient) { }

  runSeeder() : Observable<any>{
    return this._http.post(`${environment.baseApiUrl}/aa-seed-data`, null);
  }
}
