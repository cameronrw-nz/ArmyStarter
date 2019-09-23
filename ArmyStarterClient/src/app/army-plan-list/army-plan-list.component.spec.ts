import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArmyPlanListComponent } from './army-plan-list.component';

describe('ArmyPlanListComponent', () => {
  let component: ArmyPlanListComponent;
  let fixture: ComponentFixture<ArmyPlanListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArmyPlanListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArmyPlanListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
