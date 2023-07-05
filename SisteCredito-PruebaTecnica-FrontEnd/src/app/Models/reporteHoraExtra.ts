export interface ReporteHorasExtra{
  id: string | null,
  empleadoId: string,
  empleado: string,
  fecha: string,
  horasExtras: string,
  motivo: string,
  motivoRechazo: string,
  estadoId: string,
  estado: string,
  aprobadoPorLider: boolean,
  aprobadoPorTalentoHumano: boolean,
  aprobadoPorGerencia: boolean
}

export interface ReporteHorasExtraCreateDto extends Omit<ReporteHorasExtra, 'id' | 'empleado' | 'estado'>{

}

export interface ReporteHorasExtraUpdateDto extends Omit<ReporteHorasExtra, 'empleado' | 'estado'>{

}
