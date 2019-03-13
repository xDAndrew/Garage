import { Component, OnInit } from '@angular/core';
import { RepairServiceService } from '../../services/repair-service.service';
import { Observable } from 'rxjs';
import { Mark } from '../../models/mark-model';
import { Model } from '../../models/model-model';
import { VehicleNumber } from '../../models/VehicleNumber-model';

@Component({
  selector: 'app-repairs-item',
  templateUrl: './repairs-item.component.html',
  styleUrls: ['./repairs-item.component.scss'],
  providers: [ RepairServiceService ]
})
export class RepairsItemComponent implements OnInit {

  marks: Observable<Array<Mark>>;
  selectedMark: Mark;

  models: Observable<Array<Model>>;
  selectedModel: Model;

  numbers: Observable<Array<VehicleNumber>>;
  selectedNumber: VehicleNumber;

  selectedDate: Date = new Date();

  constructor(private service: RepairServiceService) { }

  ngOnInit() {
    this.marks = this.service.getMarks();
  }

  onChangeMark() {
    if (this.selectedMark) {
      this.models = this.service.getModels(this.selectedMark.id);
      this.selectedModel = null;
      this.selectedNumber = null;
    } else {
      this.models = new Observable();
      this.selectedModel = null;
    }
  }

  onChangeModel() {
    if (this.selectedModel) {
      this.numbers = this.service.getNumbers(this.selectedModel.id);
      this.selectedNumber = null;
    } else {
      this.numbers = new Observable();
      this.selectedNumber = null;
    }
  }
}
