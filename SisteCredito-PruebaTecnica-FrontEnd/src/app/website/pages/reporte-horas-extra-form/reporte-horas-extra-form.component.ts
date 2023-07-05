import { Component, OnInit } from '@angular/core';
import { ReporteHorasService } from 'src/app/services/reporteHoras/reporte-horas.service';
import { ReporteHorasExtra, ReporteHorasExtraCreateDto, ReporteHorasExtraUpdateDto } from 'src/app/Models/reporteHoraExtra';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { MetodosUtilService } from 'src/app/services/metodosUtil/metodos-util.service';
import { DDLEmpleados } from 'src/app/Models/empleados';
import { Estados } from 'src/app/Models/MetodosUtilitarios';

@Component({
  selector: 'app-reporte-horas-extra-form',
  templateUrl: './reporte-horas-extra-form.component.html',
  styleUrls: ['./reporte-horas-extra-form.component.scss']
})
export class ReporteHorasExtraFormComponent implements OnInit {

  form = new FormGroup({
    id: new FormControl(''),
    empleadoId: new FormControl('', Validators.required),
    fecha: new FormControl('', Validators.required),
    horasExtras: new FormControl('', Validators.required),
    motivo: new FormControl(''),
    motivoRechazo: new FormControl(' '),
    estadoId: new FormControl(''),
    aprobadoPorLider: new FormControl(false),
    aprobadoPorTalentoHumano: new FormControl(false),
    aprobadoPorGerencia: new FormControl(false),
  })

  reportHourId: string | null = ''
  empleadosId: DDLEmpleados[] = []
  estadosId: Estados[] = []
  datosUsuario: any = null;
  cargoUsuarioLogueado: string = '';
  nombreUsuarioLogueado: string = '';

  constructor(
    private reporteHorasService:ReporteHorasService,
    private route:Router,
    private activatedRoute:ActivatedRoute,
    private metodosUtilService:MetodosUtilService
  ) {
  }

  ngOnInit(): void {
    this.datosUsuario = localStorage.getItem('SesionUsuario');
    this.datosUsuario = JSON.parse(this.datosUsuario)
    if(this.datosUsuario)
    {
      this.cargoUsuarioLogueado = this.datosUsuario.usuario.rol
    }
    this.metodosUtilService.getEmpleados()
    .subscribe({
      next: (response) => {
        this.empleadosId = response
      }, error: (reject) => {
        console.log(reject)
      }
    })
    this.metodosUtilService.getEstados()
    .subscribe({
      next: (response) => {
        this.estadosId = response
      }, error: (reject) => {
        console.log(reject)
      }
    })
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        this.reportHourId = params.get('id')
        if(this.reportHourId != null){
          this.getReportHourById();
        }
      }, error: (response) => {
        console.log(response)
      }
    })
  }

  getReportHourById(){
    this.reporteHorasService.getReportOvertimeById(this.reportHourId!)
    .subscribe( rta => {
      console.log(rta)
      this.form.patchValue(rta);
      if (rta.empleadoId !== undefined) {
        this.form.get('empleadoId')?.setValue(rta.empleadoId.toString());
      }
      if (rta.estadoId !== undefined) {
        this.form.get('estadoId')?.setValue(rta.estadoId.toString());
      }
    })
  }

  Save(event:Event){
    if(this.form.valid){
      if(this.reportHourId == null){
        this.createReportHour()
      }
      else{
        this.updateReportHour();
      }
    }
  }

  createReportHour(){
    const data:ReporteHorasExtraCreateDto = {
      empleadoId: this.form.value.empleadoId!,
      fecha: this.form.value.fecha!,
      horasExtras: this.form.value.horasExtras!,
      motivo: this.form.value.motivo!,
      motivoRechazo: this.form.value.motivoRechazo!,
      estadoId: this.form.value.estadoId!,
      aprobadoPorLider: this.form.value.aprobadoPorLider!,
      aprobadoPorTalentoHumano: this.form.value.aprobadoPorTalentoHumano!,
      aprobadoPorGerencia: this.form.value.aprobadoPorGerencia!,
    }
    this.reporteHorasService.createReportOvertime(data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/reporte-horas-extra'])
    }, error: (error) => {
      console.log(error);
    }})
  }

  updateReportHour(){
    const data:ReporteHorasExtraUpdateDto = {
      id: this.form.value.id!,
      empleadoId: this.form.value.empleadoId!,
      fecha: this.form.value.fecha!,
      horasExtras: this.form.value.horasExtras!,
      motivo: this.form.value.motivo!,
      motivoRechazo: this.form.value.motivoRechazo!,
      estadoId: this.form.value.estadoId!,
      aprobadoPorLider: this.form.value.aprobadoPorLider!,
      aprobadoPorTalentoHumano: this.form.value.aprobadoPorTalentoHumano!,
      aprobadoPorGerencia: this.form.value.aprobadoPorGerencia!,
    }

    console.log(data);

    this.reporteHorasService.updateReportOvertime(this.reportHourId!, data)
    .subscribe({ next: (rta) => {
      this.route.navigate(['/reporte-horas-extra'])
    }, error: (error) => {
      console.log(error);
    }})
  }

  get empleadoIdField(){
    return this.form.get('empleadoId')
  }

  get fechaField(){
    return this.form.get('fecha')
  }

  get horasExtraField(){
    return this.form.get('horasExtras')
  }

  get motivoField(){
    return this.form.get('motivo')
  }

  get motivoRechazoField(){
    return this.form.get('motivoRechazo')
  }

  get estadoField(){
    return this.form.get('estado')
  }

  get aprobadoPorLiderField(){
    return this.form.get('liderId')
  }

  get aprobadoPorTalentoHumanoField(){
    return this.form.get('aprobadoPorTalentoHumano')
  }

  get aprobadoPorGerenciaField(){
    return this.form.get('aprobadoPorGerencia')
  }

}
