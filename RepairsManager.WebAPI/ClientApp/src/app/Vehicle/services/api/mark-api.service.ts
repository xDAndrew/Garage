import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { VehicleMarkModel } from '../../models/vehicleMarkModel';

@Injectable()
export class MarkApiService {

  constructor(private http: HttpClient) { }

  getMarks(): Observable<Array<VehicleMarkModel>> {
    return this.http.get<Array<VehicleMarkModel>>(window.location.protocol + '/api/mark');
  }
}
