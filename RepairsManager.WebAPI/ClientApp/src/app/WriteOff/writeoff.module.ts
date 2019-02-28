import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WoEditFormComponent } from './components/wo-edit-form/wo-edit-form.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  { path: '', component: WoEditFormComponent }
];

@NgModule({
  declarations: [WoEditFormComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    CalendarModule,
    FormsModule,
    InputTextModule,
    HttpClientModule
  ],
  providers: []
})
export class WriteoffModule { }
