import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleGridComponent } from './components/vehicle-grid/vehicle-grid.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { VehicleApiService } from './services/api/vehicle-api.service';
import { VehicleService } from './services/vehicle.service';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MarkService } from './services/mark.service';
import { MarkApiService } from './services/api/mark-api.service';
import { ModelApiService } from './services/api/model-api.service';
import { ModelService } from './services/model.service';

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
  providers: [VehicleApiService, VehicleService, MarkService, MarkApiService, ModelApiService, ModelService]
})
export class VehicleModule { }

