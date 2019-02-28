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

  postVehicle(value: vehicleModel): Observable<vehicleModel> {
    return this.http.post<vehicleModel>(window.location.protocol + '/api/vehicle', value);
  }
  
  deleteVehicle(id: number) {
    return this.http.delete(window.location.protocol + `/api/vehicle/${id}`);
  }
}
