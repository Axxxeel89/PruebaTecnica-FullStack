import { Component, OnInit, ViewChild } from '@angular/core';
import { LeaderService } from 'src/app/services/leader/leader.service';
import { Leader } from 'src/app/Models/leader';
import Swal from 'sweetalert2'
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-leader',
  templateUrl: './leader.component.html',
  styleUrls: ['./leader.component.scss']
})
export class LeaderComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Nombres', 'Apellidos', 'FechaIngreso', 'Mail', 'Cargo', 'Operaciones'];
  ListadoLideres: Leader[] = []

  dataSource = new MatTableDataSource<Leader>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  cantidadElementosMostrados = 5;
  filtroTexto = ''; // Criterio de filtro

  constructor(
    private leaderService:LeaderService
  ) { }

  ngOnInit(): void {
    this.listLeaders();
  }

  listLeaders(){
    this.leaderService.getAllLeaders()
    .subscribe({
      next: (response) => {
        this.ListadoLideres = response;
        this.dataSource = new MatTableDataSource<Leader>(response);
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

  EliminarLeader(id:string){
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
        this.leaderService.deleteLeader(id)
        .subscribe({next: (response) => {
          this.listLeaders();
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
