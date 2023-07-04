import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteHorasExtraComponent } from './reporte-horas-extra.component';

describe('ReporteHorasExtraComponent', () => {
  let component: ReporteHorasExtraComponent;
  let fixture: ComponentFixture<ReporteHorasExtraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteHorasExtraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteHorasExtraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
