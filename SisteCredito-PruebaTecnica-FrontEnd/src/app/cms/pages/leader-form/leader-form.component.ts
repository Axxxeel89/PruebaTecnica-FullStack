import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { LeaderService } from 'src/app/services/leader/leader.service';
import { Leader, LeaderDtoCreate, LeaderDtoUpdate } from 'src/app/Models/leader';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { MetodosUtilService } from 'src/app/services/metodosUtil/metodos-util.service';
import { generos, areas } from 'src/app/Models/MetodosUtilitarios';

@Component({
  selector: 'app-leader-form',
  templateUrl: './leader-form.component.html',
  styleUrls: ['./leader-form.component.scss']
})
export class LeaderFormComponent implements OnInit {


  form = new FormGroup({
    id: new FormControl(''),
    nombres: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    apellidos: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    fechaNacimiento: new FormControl('', Validators.required),
    fechaIngreso: new FormControl('', Validators.required),
    generoId: new FormControl('', Validators.required),
    mail: new FormControl('', [Validators.required, Validators.email]),
    cargo: new FormControl('Lider', Validators.required),
    areasId: new FormControl('', Validators.required),
  })


  generoId : generos[] = []
  areasId : areas[] = []
  leaderId: string | null = ''

  constructor(
    private leaderService:LeaderService,
    private route:Router,
    private activatedRoute:ActivatedRoute,
    private metodosUtilService: MetodosUtilService
  ) {

  }

  ngOnInit(): void {
    this.metodosUtilService.getGeneros()
    .subscribe({next: (response) => {
      this.generoId = response
    }, error: (error) => {
      console.log(error)
    }})
    this.metodosUtilService.getAreas()
    .subscribe({next: (response) => {
      this.areasId = response
    }, error: (error) => {
      console.log(error)
    }})

    this.activatedRoute.paramMap.subscribe( params => {
      this.leaderId = params.get('id')

      if(this.leaderId != null){
        this.getLeaderById();
      }

    })

  }

  getLeaderById(){
    this.leaderService.getLederById(this.leaderId!)
    .subscribe( rta => {
      this.form.patchValue(rta);
      if (rta.areasId !== undefined) {
        this.form.get('areasId')?.setValue(rta.areasId.toString());
      }
      if (rta.generoId !== undefined) {
        this.form.get('generoId')?.setValue(rta.generoId.toString());
      }

    })
  }

  Save(event:Event){
    if(this.form.valid){
      if(this.leaderId == null){
        this.crearLider()
      }
      else{
        this.actualizarLider();
      }
    }
  }

  crearLider(){
    const data:LeaderDtoCreate = {
      nombres: this.form.value.nombres!,
      apellidos: this.form.value.apellidos!,
      mail: this.form.value.mail!,
      cargo: this.form.value.cargo!,
      fechaNacimiento: this.form.value.fechaNacimiento!,
      fechaIngreso: this.form.value.fechaIngreso!,
      areasId: this.form.value.areasId!,
      generoId: this.form.value.generoId!,
    }
    this.leaderService.createLeader(data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/cms/leader'])
    }, error: (error) => {
      console.log(error);
    }})
  }

  actualizarLider(){
    const data:LeaderDtoUpdate = {
      id: this.form.value.id!,
      nombres: this.form.value.nombres!,
      apellidos: this.form.value.apellidos!,
      mail: this.form.value.mail!,
      cargo: this.form.value.cargo!,
      fechaNacimiento: this.form.value.fechaNacimiento!,
      fechaIngreso: this.form.value.fechaIngreso!,
      areasId: this.form.value.areasId!,
      generoId: this.form.value.generoId!,
    }


    this.leaderService.updateLeader(this.leaderId!, data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/cms/leader'])
    }, error: (error) => {
      console.log(error);
    }})
  }

  get nombreField(){
    return this.form.get('nombres')
  }

  get apellidosField(){
    return this.form.get('apellidos')
  }

  get fechaNacimientoField(){
    return this.form.get('fechaNacimiento')
  }

  get fechaIngresoField(){
    return this.form.get('fechaIngreso')
  }

  get emailField(){
    return this.form.get('mail')
  }

  get cargoField(){
    return this.form.get('cargo')
  }

  get areasField(){
    return this.form.get('areasId')
  }

  get generoField(){
    return this.form.get('generoId')
  }


}
