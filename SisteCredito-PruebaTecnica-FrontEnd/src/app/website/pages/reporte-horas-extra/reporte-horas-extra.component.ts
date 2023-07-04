import { Component, OnInit } from '@angular/core';
import { ReporteHorasService } from 'src/app/services/reporteHoras/reporte-horas.service';
import { ReporteHorasExtra } from 'src/app/Models/reporteHoraExtra';

@Component({
  selector: 'app-reporte-horas-extra',
  templateUrl: './reporte-horas-extra.component.html',
  styleUrls: ['./reporte-horas-extra.component.scss']
})
export class ReporteHorasExtraComponent implements OnInit {

  displayedColumns = ['Id','EmpleadoId', 'Fecha', 'HorasExtras', 'Motivo', 'Estado', 'Operaciones'];
  listReportOvertime : ReporteHorasExtra [] = []

  constructor(
    private reporteHorasService:ReporteHorasService
  ) { }

  ngOnInit(): void {
    this.listReportOvertimes;
  }

  listReportOvertimes(){
    this.reporteHorasService.getAllReportOvertime()
    .subscribe({next: (response) => {
      this.listReportOvertime = response
    }, error: (response) => {
      console.log(response)
    }
  })
  }

  applyFilter(event: Event){

  }

  deleteReportOvertime(id:string){

  }

}
