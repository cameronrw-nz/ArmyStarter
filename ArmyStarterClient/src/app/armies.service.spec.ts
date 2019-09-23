import { TestBed } from '@angular/core/testing';

import { ArmiesService } from './armies.service';

describe('ArmiesService', () => {
  let service: ArmiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArmiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
