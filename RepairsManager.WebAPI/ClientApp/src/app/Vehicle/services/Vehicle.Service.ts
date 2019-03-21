import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { vehicleModel } from '../models/VehicleModel';
import { VehicleApiService } from './api/vehicle-api.service';

@Injectable()
export class VehicleService {

    constructor(private vehicleApi: VehicleApiService) {
        vehicleApi.getVehicles().subscribe(x => {
            this.data = x;
            this.instance$.next(this.data);
        });
    }

    private data: Array<vehicleModel>;
    private instance$: Subject<Array<vehicleModel>> = new Subject();

    get collection(): Observable<Array<vehicleModel>> {
        return this.instance$.asObservable();
    }

    public SetVehicle(model: vehicleModel) {
        this.vehicleApi.postVehicle(model).subscribe(() => {
            this.data.push(model);
            this.instance$.next(this.data);
        });
    }

    public Update(model: vehicleModel) {
        let index = this.data.findIndex(x => x.id == model.id);
        if (index > -1) {
            this.data.splice(index, 1);
            this.instance$.next(this.data);
        }
    }

    public RemoveVehicle(id: number) {
        let index = this.data.findIndex(x => x.id == id);
        if (index > -1) {
            this.vehicleApi.deleteVehicle(this.data[index].id).subscribe();
            this.data.splice(index, 1);
            this.instance$.next(this.data);
        }
    }
    public GetVehicleId(id: number): vehicleModel {
        let index = this.data.findIndex(x => x.id == id);
        return this.data[index];
    }
}
