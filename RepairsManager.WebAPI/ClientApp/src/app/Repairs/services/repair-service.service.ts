import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RepairModel } from '../models/repair-model';

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
}
