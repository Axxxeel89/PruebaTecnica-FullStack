import { TestBed } from '@angular/core/testing';

import { MetodosUtilService } from './metodos-util.service';

describe('MetodosUtilService', () => {
  let service: MetodosUtilService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MetodosUtilService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
