import { Component, OnInit } from '@angular/core';
import { ReporteHorasService } from 'src/app/services/reporteHoras/reporte-horas.service';
import { ReporteHorasExtra } from 'src/app/Models/reporteHoraExtra';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-reporte-horas-extra',
  templateUrl: './reporte-horas-extra.component.html',
  styleUrls: ['./reporte-horas-extra.component.scss']
})
export class ReporteHorasExtraComponent implements OnInit {

  displayedColumns = ['Id','Empleado', 'Fecha', 'HorasExtras', 'Motivo', 'Estado', 'Operaciones'];
  listReportOvertime : ReporteHorasExtra [] = []

  datosUsuario: any = null;
  nombreUsuarioLogueado: string = '';

  constructor(
    private reporteHorasService:ReporteHorasService
  ) { }

  ngOnInit(): void {
    this.datosUsuario = localStorage.getItem('SesionUsuario');
    this.datosUsuario = JSON.parse(this.datosUsuario)
    if(this.datosUsuario)
    {
      this.nombreUsuarioLogueado = this.datosUsuario.usuario.nombre
      console.log(this.nombreUsuarioLogueado)
    }
    this.listReportOvertimes();

  }

  listReportOvertimes(){
    this.reporteHorasService.getAllReportOvertime(this.nombreUsuarioLogueado)
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
    Swal.fire({
      title: 'Estas seguro?',
      text: "Si eliminas el registro sera de forma permanente",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.reporteHorasService.deleteReportOvertime(id)
        .subscribe({
          next: (response) => {
            this.listReportOvertimes()
          }, error: (response)=> {
            console.log(response)
          }
        })
        Swal.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        )
      }
    })


  }

}
