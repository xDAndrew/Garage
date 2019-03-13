import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { RepairsGridComponent } from '../Repairs/Components/repairs-grid/repairs-grid.component';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { RepairsItemComponent } from '../Repairs/Components/repairs-item/repairs-item.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';

const routes: Routes = [
  { path: '', component: RepairsGridComponent },
  { path: 'form', component: RepairsItemComponent },
  { path: 'form/:id', component: RepairsItemComponent }
];

@NgModule({
  declarations: [ RepairsGridComponent, RepairsItemComponent ],
  imports: [
    FormsModule,
    CommonModule,
    RouterModule.forChild(routes),
    TableModule,
    HttpClientModule,
    NgSelectModule,
    ButtonModule,
    CalendarModule
  ]
})
export class RepairsModule { }
