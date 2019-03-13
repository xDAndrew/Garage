import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RepairsItemComponent } from './repairs-item.component';

describe('RepairsItemComponent', () => {
  let component: RepairsItemComponent;
  let fixture: ComponentFixture<RepairsItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RepairsItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RepairsItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
