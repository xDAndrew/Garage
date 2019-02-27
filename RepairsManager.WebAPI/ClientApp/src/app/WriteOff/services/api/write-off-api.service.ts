import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { State } from '../../models/state';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WriteOffApiService {

  constructor(private http: HttpClient) { }

  getWriteOffState(): Observable<State> {
    return this.http.get<State>(window.location.protocol + '/api/workoff');
  }

  getDocument(date: Date): void {
    window.location.href = window.location.protocol + `/api/workoff/getdocument/${date.toISOString()}`;
  }

  putWriteOffState(value: State) {
    return this.http.put<State>(window.location.protocol + '/api/workoff', value);
  }
}
