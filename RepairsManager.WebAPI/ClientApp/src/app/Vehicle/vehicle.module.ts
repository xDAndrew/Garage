import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleGridComponent } from './components/vehicle-grid/vehicle-grid.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { VehicleApiService } from './services/api/vehicle-api.service';
import { VehicleService } from './services/Vehicle.Service';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';

@NgModule({
  declarations: [VehicleGridComponent, VehicleFormComponent, VehicleFormComponent],
  imports: [
    CommonModule,
    TableModule,
    HttpClientModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    ButtonModule,
    CardModule
  ],
  exports: [VehicleGridComponent, VehicleFormComponent],
  providers: [VehicleApiService, VehicleService]
})
export class VehicleModule { }
