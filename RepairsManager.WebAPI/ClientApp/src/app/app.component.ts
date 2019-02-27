import { Component } from '@angular/core';
import { WriteOffApiService } from './WriteOff/services/api/write-off-api.service';
import { State } from './WriteOff/models/state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(api: WriteOffApiService) { 
    let item: State;
    api.getWriteOffState().subscribe(x => {
      item = x;
      item.director = 'A.Д.Иванов';
      api.putWriteOffState(item).subscribe(() => { 
        api.getDocument(new Date());
      });
    });
  }

  title = 'ClientApp';
}
