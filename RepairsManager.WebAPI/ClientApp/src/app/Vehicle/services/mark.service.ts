import { Injectable } from '@angular/core';
import { MarkApiService } from './api/mark-api.service';
import { VehicleMarkModel } from '../models/vehicleMarkModel';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class MarkService {

  constructor(private markApi: MarkApiService) {
    markApi.getMarks().subscribe(x => {
      this.data = x;
      this.instance$.next(this.data);
      console.log(this.data);
    });
  }

  private data: Array<VehicleMarkModel>;
  private instance$: Subject<Array<VehicleMarkModel>> = new Subject();

  get collection(): Observable<Array<VehicleMarkModel>> {
    return this.instance$.asObservable();
  }

  public SetVehicle(model: VehicleMarkModel) {
    this.data.push(model);
    this.instance$.next(this.data);
  }

  public Update(model: VehicleMarkModel) {
    let index = this.data.findIndex(x => x.id == model.id);
    if (index > -1) {
      this.data.splice(index, 1);
      this.instance$.next(this.data);
    }
  }

  public RemoveVehicle(id: number) {
    let index = this.data.findIndex(x => x.id == id);
    if (index > -1) {
      this.data.splice(index, 1);
      this.instance$.next(this.data);
    }
  }
}
