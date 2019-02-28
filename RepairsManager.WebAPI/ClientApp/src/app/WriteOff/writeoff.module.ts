import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WoEditFormComponent } from './components/wo-edit-form/wo-edit-form.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { FieldsetModule } from 'primeng/fieldset';

@NgModule({
  declarations: [WoEditFormComponent],
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule,
    InputTextModule,
    FieldsetModule
  ],
  exports: [
    WoEditFormComponent
  ]
})
export class WriteoffModule { }
