import { Component, OnInit, ViewChild } from '@angular/core';
import { ReporteHorasService } from 'src/app/services/reporteHoras/reporte-horas.service';
import { ReporteHorasExtra } from 'src/app/Models/reporteHoraExtra';
import Swal from 'sweetalert2'
import { MetodosUtilService } from 'src/app/services/metodosUtil/metodos-util.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-reporte-horas-extra',
  templateUrl: './reporte-horas-extra.component.html',
  styleUrls: ['./reporte-horas-extra.component.scss']
})
export class ReporteHorasExtraComponent implements OnInit {

  displayedColumns = ['Id','Empleado', 'Fecha', 'HorasExtras', 'Motivo', 'Estado', 'Operaciones'];
  listReportOvertime: ReporteHorasExtra[] = [];

  dataSource = new MatTableDataSource<ReporteHorasExtra>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  datosUsuario: any = null;
  nombreUsuarioLogueado: string = '';
  rolUsuario: string = '';

  SumatoriaHora: any = 0;

  cantidadElementosMostrados = 5;
  filtroTexto = ''; // Criterio de filtro

  constructor(
    private reporteHorasService:ReporteHorasService,
    private metodosUtilService: MetodosUtilService
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
    this.metodosUtilService.getSumatoriaHoras(this.nombreUsuarioLogueado)
    .subscribe({
      next: (response) => {
        this.SumatoriaHora = response;
      }, error: (response) => {
        console.log(response)
      }
    })

  }


  listReportOvertimes(){
    this.rolUsuario = this.datosUsuario.usuario.rol;
    this.reporteHorasService.getAllReportOvertime(this.nombreUsuarioLogueado)
    .subscribe({next: (response) => {
      this.listReportOvertime = response
      this.dataSource = new MatTableDataSource<ReporteHorasExtra>(response);
      this.dataSource.paginator = this.paginator;
      this.paginator.length = response.length;
    }, error: (response) => {
      console.log(response)
    }
  })
  }

  mostrarLista(cantidad:number){
    this.cantidadElementosMostrados = cantidad;
  }

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
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
