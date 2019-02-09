import { Component, OnInit } from '@angular/core';
import { VehicleMarkModel } from '../../models/vehicleMarkModel';
import { Observable } from 'rxjs';
import { MarkService } from '../../services/mark.service';
import { ModelService } from '../../services/model.service';
import { ModelVehicle } from '../../models/modelVehicle';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {

  private marks: Observable<Array<VehicleMarkModel>>;
  private model: Observable<Array<ModelVehicle>>;
  private selectedMark: VehicleMarkModel;
  text: string;

  constructor(private markService: MarkService, private modelService: ModelService) { }

  ngOnInit() {
    this.marks = this.markService.collection;
    this.model = this.modelService.collection;
  }
  getId() {

  }
}
