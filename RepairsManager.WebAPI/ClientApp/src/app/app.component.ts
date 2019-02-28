import { Component } from '@angular/core';
import { WriteOffApiService } from './WriteOff/services/api/write-off-api.service';
import { State } from './WriteOff/models/state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
}
