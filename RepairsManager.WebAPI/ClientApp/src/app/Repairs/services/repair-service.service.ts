import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RepairModel } from '../models/repair-model';
import { Mark } from '../models/mark-model';
import { Model } from '../models/model-model';
import { VehicleNumber } from '../models/VehicleNumber-model';

@Injectable()
export class RepairServiceService {

  constructor(private http: HttpClient) { }

  getRepairs(): Observable<Array<RepairModel>> {
    return this.http.get<Array<RepairModel>>(window.location.protocol + '/api/repairs');
  }

  postRepairs(value: RepairModel): Observable<RepairModel> {
    return this.http.post<RepairModel>(window.location.protocol + '/api/repairs', value);
  }
  
  deleteRepairs(id: number) {
    return this.http.delete(window.location.protocol + `/api/repairs/${id}`);
  }

  getMarks() {
    return this.http.get<Array<Mark>>(window.location.protocol + '/api/Mark');
  }

  getModels(id: number) {
    return this.http.get<Array<Model>>(window.location.protocol + `/api/Model/${id}`);
  }

  getNumbers(id: number) {
    return this.http.get<Array<VehicleNumber>>(window.location.protocol + `api/Vehicle/${id}`);
  }
}
