import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RepairsMappingComponent } from './repairs-mapping/repairs-mapping.component';

const routes: Routes = [
  { path:'', component: RepairsMappingComponent }
];

@NgModule({
  declarations: [ RepairsMappingComponent ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ]
})
export class RepairsMappingModule { }
