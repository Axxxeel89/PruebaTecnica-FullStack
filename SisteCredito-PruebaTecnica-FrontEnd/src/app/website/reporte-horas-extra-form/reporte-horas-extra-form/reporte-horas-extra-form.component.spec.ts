import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteHorasExtraFormComponent } from './reporte-horas-extra-form.component';

describe('ReporteHorasExtraFormComponent', () => {
  let component: ReporteHorasExtraFormComponent;
  let fixture: ComponentFixture<ReporteHorasExtraFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteHorasExtraFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReporteHorasExtraFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
