import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitCalculatorComponent } from './unit-calculator.component';

describe('UnitCalculatorComponent', () => {
  let component: UnitCalculatorComponent;
  let fixture: ComponentFixture<UnitCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnitCalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnitCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
