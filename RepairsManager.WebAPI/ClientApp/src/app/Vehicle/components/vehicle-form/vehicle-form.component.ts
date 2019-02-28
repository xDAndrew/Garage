import { Component, OnInit, Output } from '@angular/core';
import { VehicleMarkModel } from '../../models/vehicleMarkModel';
import { Observable, fromEvent } from 'rxjs';
import { MarkService } from '../../services/mark.service';
import { ModelService } from '../../services/model.service';
import { ModelVehicle } from '../../models/modelVehicle';
import { VehicleService } from '../../services/vehicle.service';
import { vehicleModel } from '../../models/VehicleModel';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss'],
  providers: [ VehicleService, MarkService, ModelService ]
})
export class VehicleFormComponent implements OnInit {
  private marks: Observable<Array<VehicleMarkModel>>;
  private models: Array<ModelVehicle>;
  private selectedMark: VehicleMarkModel;
  private selectedModel: VehicleMarkModel;

  text: string;

  constructor(private vehicleService: VehicleService, private markService: MarkService, private modelService: ModelService) { }

  ngOnInit() {
    this.marks = this.markService.collection;
  }

  setModels() {
    this.models = this.modelService.getModelById(this.selectedMark.id);
    if (!!this.models && !!this.models.length) {
      this.selectedModel = this.models[0];
    }
  }

  public get validModel(): boolean {
    return this.selectedMark && this.selectedModel && !!this.text;
  }

  public addVehicle() {
    let item = new vehicleModel();
    item.regNumber = this.text;
    item.modelName = this.selectedModel.name;
    item.markName = this.selectedMark.name;
    item.modelId = this.selectedModel.id;
    this.vehicleService.SetVehicle(item);
  }
}
