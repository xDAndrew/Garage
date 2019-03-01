import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RepairModel } from '../../models/repair-model';
import { RepairServiceService } from '../../services/repair-service.service';

@Component({
  selector: 'app-repairs-grid',
  templateUrl: './repairs-grid.component.html',
  styleUrls: ['./repairs-grid.component.scss'],
  providers: [ RepairServiceService ]
})
export class RepairsGridComponent implements OnInit {

  private repairs: Observable<Array<RepairModel>>;
  private selectedRepair: RepairModel;

  cols: any[] = [
    { field: 'id', header: '#' },
    { field: 'vehicleModel', header: 'Марка / модель' },
    { field: 'vehicleNumber', header: 'Гос. №' },
    { field: 'repairDate', header: 'Дата ремонта' },
    { field: 'employee', header: 'Слесарь' }
  ];

  constructor(private repairsService: RepairServiceService) { }

  ngOnInit() {
    this.repairs = this.repairsService.getRepairs();
  }

  removeVehicle(id: number) {
    this.repairsService.deleteRepairs(id);
  }
}
