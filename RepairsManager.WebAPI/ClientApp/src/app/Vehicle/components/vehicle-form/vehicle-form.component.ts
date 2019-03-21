import { Component, OnInit, Output } from '@angular/core';
import { VehicleMarkModel } from '../../models/vehicleMarkModel';
import { Observable, fromEvent, Subscription } from 'rxjs';
import { MarkService } from '../../services/mark.service';
import { ModelService } from '../../services/model.service';
import { ModelVehicle } from '../../models/modelVehicle';
import { VehicleService } from '../../services/vehicle.service';
import { vehicleModel } from '../../models/VehicleModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss'],
  providers: [VehicleService, MarkService, ModelService]
})
export class VehicleFormComponent implements OnInit {
  private marks: Observable<Array<VehicleMarkModel>>;
  private models: Array<ModelVehicle>;
  private selectedMark: VehicleMarkModel;
  private selectedModel: VehicleMarkModel;
  private id: number;
  private subscription: Subscription
  private MarkVehicle: vehicleModel;
  text: string;


  constructor(private vehicleService: VehicleService, private markService: MarkService, private modelService: ModelService,
    private activatedRouter: ActivatedRoute) { }

  ngOnInit() {
    this.marks = this.markService.collection;
    this.subscription = this.activatedRouter.params.subscribe(params => this.id = params['id']);
    if (undefined != this.id) {
      this.vehicleService.collection.subscribe(x => this.editVehicle());
    }
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
  public editVehicle() {
    let d;
    d = this.vehicleService.GetVehicleId(this.id);
    console.log(d);
  }
}
