import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ModelVehicle } from '../../models/modelVehicle';

@Injectable()
export class ModelApiService {

    constructor(private http: HttpClient) { }

    getModel(): Observable<Array<ModelVehicle>> {
        return this.http.get<Array<ModelVehicle>>(window.location.protocol + 'api/Model');
    }
}