import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { EmpleadosService } from 'src/app/services/empleados/empleados.service';
import { EmpleadoUpdateDto, Empleados, EmpleadosCreateDto } from 'src/app/Models/empleados';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { MetodosUtilService } from 'src/app/services/metodosUtil/metodos-util.service';
import { generos, areas, DDLlideres } from 'src/app/Models/MetodosUtilitarios';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {

  form = new FormGroup({
    id: new FormControl(''),
    nombres: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    apellidos: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    fechaNacimiento: new FormControl('', Validators.required),
    fechaIngreso: new FormControl('', Validators.required),
    fechaRetiro: new FormControl(''),
    usuarioHabilitado: new FormControl(false),
    generoId: new FormControl('', Validators.required),
    mail: new FormControl('', [Validators.required, Validators.email]),
    cargo: new FormControl('Empleado', Validators.required),
    areasId: new FormControl('', Validators.required),
    liderId: new FormControl('', Validators.required),
  })

  generoId : generos[] = []
  areasId : areas[] = []
  liderId : DDLlideres[] = []
  employeeId: string | null = ''

  constructor(
    private empleadosService:EmpleadosService,
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
    this.metodosUtilService.getLideres()
    .subscribe({next: (response) => {
      this.liderId = response
    }, error: (error) => {
      console.log(error)
    }})

    this.activatedRoute.paramMap.subscribe( params => {
      this.employeeId = params.get('id')

      if(this.employeeId != null){
        this.getEmployeeById();
      }

    })
  }

  getEmployeeById(){
    this.empleadosService.getEmployeeById(this.employeeId!)
    .subscribe( rta => {
      this.form.patchValue(rta);
      if (rta.areasId !== undefined) {
        this.form.get('areasId')?.setValue(rta.areasId.toString());
      }
      if (rta.generoId !== undefined) {
        this.form.get('generoId')?.setValue(rta.generoId.toString());
      }
      if (rta.liderId !== undefined) {
        this.form.get('liderId')?.setValue(rta.liderId.toString());
      }

    })
  }

  Save(event:Event){
    if(this.form.valid){
      if(this.employeeId == null){
        this.createEmployee()
      }
      else{
        this.updateEmployee();
      }
    }
  }

  createEmployee(){
    const data:EmpleadosCreateDto = {
      nombres: this.form.value.nombres!,
      apellidos: this.form.value.apellidos!,
      mail: this.form.value.mail!,
      cargo: this.form.value.cargo!,
      fechaNacimiento: this.form.value.fechaNacimiento!,
      fechaIngreso: this.form.value.fechaIngreso!,
      usuarioHabilitado: this.form.value.usuarioHabilitado!,
      areasId: this.form.value.areasId!,
      generoId: this.form.value.generoId!,
      liderId: this.form.value.liderId!,
    }
    this.empleadosService.createEmployee(data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/cms/employee'])
    }, error: (error) => {
      console.log(error);
    }})
  }

  updateEmployee(){
    const data:EmpleadoUpdateDto = {
      id: this.form.value.id!,
      nombres: this.form.value.nombres!,
      apellidos: this.form.value.apellidos!,
      mail: this.form.value.mail!,
      cargo: this.form.value.cargo!,
      fechaNacimiento: this.form.value.fechaNacimiento!,
      usuarioHabilitado: this.form.value.usuarioHabilitado!,
      fechaIngreso: this.form.value.fechaIngreso!,
      fechaRetiro: this.form.value.fechaIngreso!,
      areasId: this.form.value.areasId!,
      generoId: this.form.value.generoId!,
      liderId: this.form.value.liderId!,
    }


    this.empleadosService.updateEmployee(this.employeeId!, data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/cms/employee'])
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

  get liderField(){
    return this.form.get('liderId')
  }

  get areasField(){
    return this.form.get('areasId')
  }

  get generoField(){
    return this.form.get('generoId')
  }

  get fechaRetiroField(){
    return this.form.get('fechaRetiro')
  }


}
