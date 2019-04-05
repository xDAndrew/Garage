import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'Repairs', loadChildren: './Repairs/repairs.module#RepairsModule'},
  { path: '', loadChildren: './Vehicle/vehicle.module#VehicleModule', },
  { path: 'WorkOffForm', loadChildren: './WriteOff/writeoff.module#WriteoffModule', },
  { path: 'RepairsMapping', loadChildren: './RepairsMapping/repairs-mapping.module#RepairsMappingModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
