import { Injectable } from '@angular/core';
import { ModelApiService } from './api/model-api.service';
import { Subject, Observable } from 'rxjs';
import { ModelVehicle } from '../models/modelVehicle';

@Injectable()
export class ModelService {

    private data: Array<ModelVehicle>;
    private instanse: Subject<Array<ModelVehicle>> = new Subject();

    constructor(private modelApi: ModelApiService) {
        this.modelApi.getModel().subscribe(x => {
            this.data = x;
            this.instanse.next(this.data);
        });

    }

    get collection(): Observable<Array<ModelVehicle>> {
        return this.instanse.asObservable();
    }
    public getModelById(Id: number): Array<ModelVehicle> {
        return this.data.filter(x => x.vehicleMarkId == Id);
    }
}