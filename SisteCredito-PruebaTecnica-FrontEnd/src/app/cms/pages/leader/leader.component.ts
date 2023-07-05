import { Component, OnInit } from '@angular/core';
import { LeaderService } from 'src/app/services/leader/leader.service';
import { Leader } from 'src/app/Models/leader';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-leader',
  templateUrl: './leader.component.html',
  styleUrls: ['./leader.component.scss']
})
export class LeaderComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Nombres', 'Apellidos', 'FechaIngreso', 'Mail', 'Cargo', 'Operaciones'];
  ListadoLideres: Leader[] = []

  constructor(
    private leaderService:LeaderService
  ) { }

  ngOnInit(): void {
    this.listLeaders();
  }

  listLeaders(){
    this.leaderService.getAllLeaders()
    .subscribe( rta => {
      this.ListadoLideres = rta;
    })
  }

  applyFilter(event: Event){

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
