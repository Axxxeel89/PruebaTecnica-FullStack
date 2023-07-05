import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from 'src/app/services/empleados/empleados.service';
import { Router } from '@angular/router';
import { Empleados } from 'src/app/Models/empleados';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  displayedColumns = ['Id', 'Nombres', 'Apellidos', 'FechaIngreso', 'FechaRetiro', 'Mail', 'Operaciones'];

  ListEmployee: Empleados[] = []

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
    }, error: (response) => {
      console.log(response)
    }
    })
  }

  applyFilter(event: Event){

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
