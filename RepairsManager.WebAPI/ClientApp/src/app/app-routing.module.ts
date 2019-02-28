import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'Auto', loadChildren: './Vehicle/vehicle.module#VehicleModule', },
  { path: 'WorkOffForm', loadChildren: './WriteOff/writeoff.module#WriteoffModule', },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
