import { TestBed } from '@angular/core/testing';

import { ReporteHorasService } from './reporte-horas.service';

describe('ReporteHorasService', () => {
  let service: ReporteHorasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReporteHorasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
