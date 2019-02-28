import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleGridComponent } from './components/vehicle-grid/vehicle-grid.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { VehicleApiService } from './services/api/vehicle-api.service';
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
import { Routes, RouterModule } from '@angular/router';
import { NgSelectModule } from '@ng-select/ng-select';

const routes: Routes = [
  { path: '', component: VehicleGridComponent },
  { path: 'form', component: VehicleFormComponent },
  { path: 'form/:id', component: VehicleFormComponent },
];

@NgModule({
  declarations: [VehicleGridComponent, VehicleFormComponent, VehicleFormComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    TableModule,
    HttpClientModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    ButtonModule,
    CardModule,
    NgSelectModule
  ],
  exports: [],
  providers: [VehicleApiService, MarkService, MarkApiService, ModelApiService, ModelService]
})
export class VehicleModule { }

