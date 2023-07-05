import { Component, OnInit, ViewChild } from '@angular/core';
import { EmpleadosService } from 'src/app/services/empleados/empleados.service';
import { Router } from '@angular/router';
import { Empleados } from 'src/app/Models/empleados';
import Swal from 'sweetalert2'
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  displayedColumns = ['Id', 'Nombres', 'Apellidos', 'FechaIngreso', 'FechaRetiro', 'Mail', 'Cargo', 'Operaciones'];

  ListEmployee: Empleados[] = []

  dataSource = new MatTableDataSource<Empleados>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  cantidadElementosMostrados = 5;
  filtroTexto = ''; // Criterio de filtro

  constructor(
    private empleadosService:EmpleadosService,
    private router:Router

  ) {

  }

  ngOnInit(): void {
    this.listEmployees();
  }

  listEmployees(){
    this.empleadosService.getAllEmployee()
    .subscribe({ next: (response) => {
      this.ListEmployee = response;
      this.dataSource = new MatTableDataSource<Empleados>(response);
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

  deleteEmployee(id:string){
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
        this.empleadosService.deleteEmployee(id)
        .subscribe({next: (response) => {
          this.listEmployees();
        }, error: (response) => {
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
