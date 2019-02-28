import { Component, OnInit } from '@angular/core';
import { WriteOffApiService } from '../../services/api/write-off-api.service';
import { State } from '../../models/state';

@Component({
  selector: 'app-wo-edit-form',
  templateUrl: './wo-edit-form.component.html',
  styleUrls: ['./wo-edit-form.component.scss']
})
export class WoEditFormComponent implements OnInit {

  public model: State;
  public period: Date = new Date();

  constructor(private api:WriteOffApiService) { }

  ngOnInit() {
    this.api.getWriteOffState().subscribe((data) => {this.model = data});
  }

  getDocument() {
    this.api.getDocument(this.period);
  }

}
