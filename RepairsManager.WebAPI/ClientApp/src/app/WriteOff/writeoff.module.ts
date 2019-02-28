import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WoEditFormComponent } from './components/wo-edit-form/wo-edit-form.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [WoEditFormComponent],
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule
  ],
  exports: [
    WoEditFormComponent
  ]
})
export class WriteoffModule { }
