import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArmyPlanComponent } from './army-plan.component';

describe('ArmyPlanComponent', () => {
  let component: ArmyPlanComponent;
  let fixture: ComponentFixture<ArmyPlanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArmyPlanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArmyPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
