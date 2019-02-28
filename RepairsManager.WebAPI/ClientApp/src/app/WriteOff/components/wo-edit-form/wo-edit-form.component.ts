import { Component, OnInit } from '@angular/core';
import { WriteOffApiService } from '../../services/api/write-off-api.service';
import { State, Member } from '../../models/state';

@Component({
  selector: 'app-wo-edit-form',
  templateUrl: './wo-edit-form.component.html',
  styleUrls: ['./wo-edit-form.component.scss'],
  providers: [ WriteOffApiService ]
})
export class WoEditFormComponent implements OnInit {

  public model: State;
  public period: Date = new Date();
  public loaded: boolean = false;

  constructor(private api: WriteOffApiService) { }

  ngOnInit() {
    this.api.getWriteOffState().subscribe((data) => {
      this.model = data;
      this.model.commission.createDate = new Date(this.model.commission.createDate);
      this.loaded = true;
    });
  }

  getDocument() {
    this.api.getDocument(this.period);
  }

  removeEmployee(index: number) {
    this.model.commission.members.splice(index, 1);
  }

  addNewEmployee() {
    this.model.commission.members.push(new Member());
  }

  saveModel() {
    this.api.putWriteOffState(this.model).subscribe();
  }

  getSaveValidation() {
    let result: boolean =
      !!this.model.organization &&
      !!this.model.director &&
      !!this.model.department &&
      !!this.model.commission.members.length &&
      !!this.model.commission.chairman &&
      !!this.model.commission.createDate &&
      !!this.model.commission.number;
    this.model.commission.members.forEach((elenet) => {
      result = result && !!elenet.name && !!elenet.place;
    });
    return !result;
  }

  getValidation() {
    return !this.period;
  }
}
