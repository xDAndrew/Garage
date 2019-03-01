import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RepairsGridComponent } from './repairs-grid.component';

describe('RepairsGridComponent', () => {
  let component: RepairsGridComponent;
  let fixture: ComponentFixture<RepairsGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RepairsGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RepairsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
