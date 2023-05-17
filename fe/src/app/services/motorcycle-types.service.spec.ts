import { TestBed } from '@angular/core/testing';

import { MotorcycleTypesService } from './motorcycle-types.service';

describe('MotorcycleTypesService', () => {
  let service: MotorcycleTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MotorcycleTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
