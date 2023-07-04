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
    horasExtra: new FormControl('', Validators.required),
    motivo: new FormControl(''),
    motivoRechazo: new FormControl(),
    estado: new FormControl(''),
    aprobadoPorLider: new FormControl(false),
    aprobadoPorTalentoHumano: new FormControl(false),
    aprobadoPorGerencia: new FormControl(false),
  })

  reportHourId: string | null = ''
  empleadosId: DDLEmpleados[] = []
  estadosId: Estados[] = []

  constructor(
    private reporteHorasService:ReporteHorasService,
    private route:Router,
    private activatedRoute:ActivatedRoute,
    private metodosUtilService:MetodosUtilService
  ) {
  }

  ngOnInit(): void {
    this.metodosUtilService.getEmpleados()
    .subscribe({
      next: (response) => {
        this.empleadosId = response
        console.log(response)
      }, error: (reject) => {
        console.log(reject)
      }
    })
    this.metodosUtilService.getEstados()
    .subscribe({
      next: (response) => {
        this.estadosId = response
        console.log(response)
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
      this.form.patchValue(rta);
      if (rta.empleadoId !== undefined) {
        this.form.get('empleadoId')?.setValue(rta.empleadoId.toString());
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
      horasExtra: this.form.value.horasExtra!,
      motivo: this.form.value.motivo!,
      motivoRechazo: this.form.value.motivoRechazo!,
      estado: this.form.value.estado!,
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
    const data:ReporteHorasExtra = {
      id: this.form.value.id!,
      empleadoId: this.form.value.empleadoId!,
      fecha: this.form.value.fecha!,
      horasExtra: this.form.value.horasExtra!,
      motivo: this.form.value.motivo!,
      motivoRechazo: this.form.value.motivoRechazo!,
      estado: this.form.value.estado!,
      aprobadoPorLider: this.form.value.aprobadoPorLider!,
      aprobadoPorTalentoHumano: this.form.value.aprobadoPorTalentoHumano!,
      aprobadoPorGerencia: this.form.value.aprobadoPorGerencia!,
    }


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
    return this.form.get('horasExtra')
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
