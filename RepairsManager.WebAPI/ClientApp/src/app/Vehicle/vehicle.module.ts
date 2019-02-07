import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleGridComponent } from './components/vehicle-grid/vehicle-grid.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { VehicleApiService } from './services/api/vehicle-api.service';

@NgModule({
  declarations: [VehicleGridComponent],
  imports: [
    CommonModule,
    TableModule,
    HttpClientModule
  ],
  exports: [VehicleGridComponent],
  providers: [VehicleApiService]
})
export class VehicleModule { }
