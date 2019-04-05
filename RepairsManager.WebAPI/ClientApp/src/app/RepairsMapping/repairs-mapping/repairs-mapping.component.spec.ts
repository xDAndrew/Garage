import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RepairsMappingComponent } from './repairs-mapping.component';

describe('RepairsMappingComponent', () => {
  let component: RepairsMappingComponent;
  let fixture: ComponentFixture<RepairsMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RepairsMappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RepairsMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
