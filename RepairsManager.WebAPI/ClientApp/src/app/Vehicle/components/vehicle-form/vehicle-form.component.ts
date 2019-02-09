import { Component, OnInit } from '@angular/core';
import { VehicleMarkModel } from '../../models/vehicleMarkModel';
import { Observable } from 'rxjs';
import { MarkService } from '../../services/mark.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {

  private marks: Observable<Array<VehicleMarkModel>>;
  private selectedMark: VehicleMarkModel;

  text: string;

  constructor(private markService: MarkService) { }

  ngOnInit() {
    this.marks = this.markService.collection;
  }

}
