import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { RepairsGridComponent } from '../Repairs/Components/repairs-grid/repairs-grid.component';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';

const routes: Routes = [
  { path: '', component: RepairsGridComponent }
];

@NgModule({
  declarations: [ RepairsGridComponent ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    TableModule,
    HttpClientModule
  ]
})
export class RepairsModule { }
