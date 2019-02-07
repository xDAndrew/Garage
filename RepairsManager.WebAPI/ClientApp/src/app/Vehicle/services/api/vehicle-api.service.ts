import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { vehicleModel } from '../../models/VehicleModel';

@Injectable()
export class VehicleApiService {

  constructor(private http: HttpClient) { }

  getVehicles(): Observable<Array<vehicleModel>> {
    return this.http.get<Array<vehicleModel>>(window.location.protocol + '/api/vehicle');
  }
}
