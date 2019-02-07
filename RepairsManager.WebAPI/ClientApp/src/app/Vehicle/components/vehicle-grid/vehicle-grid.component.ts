import { Component, OnInit } from '@angular/core';
import { VehicleApiService } from '../../services/api/vehicle-api.service';
import { Observable } from 'rxjs';
import { vehicleModel } from '../../models/VehicleModel';

@Component({
  selector: 'app-vehicle-grid',
  templateUrl: './vehicle-grid.component.html',
  styleUrls: ['./vehicle-grid.component.scss']
})
export class VehicleGridComponent implements OnInit {

  private vehilces: Observable<Array<vehicleModel>>;

  cols: any[] = [
    { field: 'id', header: '#' },
    { field: 'markName', header: 'Марка' },
    { field: 'modelName', header: 'Модель' },
    { field: 'regNumber', header: 'Гос. №' }
  ];

  constructor(private vehicleApi: VehicleApiService) { }

  ngOnInit() {
    this.vehilces = this.vehicleApi.getVehicles();
  }

}
