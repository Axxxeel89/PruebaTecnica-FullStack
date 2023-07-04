import { Component, OnInit } from '@angular/core';
import { LeaderService } from 'src/app/services/leader/leader.service';
import { Leader } from 'src/app/Models/leader';

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
    this.leaderService.deleteLeader(id)
    .subscribe({next: (response) => {
      this.listLeaders();
    }, error: (response) => {
      console.log(response)
    }
    })
  }

}
