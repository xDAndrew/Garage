import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WoEditFormComponent } from './wo-edit-form.component';

describe('WoEditFormComponent', () => {
  let component: WoEditFormComponent;
  let fixture: ComponentFixture<WoEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WoEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WoEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
