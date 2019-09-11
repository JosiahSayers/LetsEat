import { TestBed } from '@angular/core/testing';

import { LOGGERService } from './logger.service';

describe('LOGGERService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LOGGERService = TestBed.get(LOGGERService);
    expect(service).toBeTruthy();
  });
});
