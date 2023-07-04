export interface ReporteHorasExtra{
  id: string | null,
  empleadoId: string,
  empleado?: string,
  fecha: string,
  horasExtra: string,
  motivo: string,
  motivoRechazo: string,
  estado: string,
  aprobadoPorLider: boolean,
  aprobadoPorTalentoHumano: boolean,
  aprobadoPorGerencia: boolean
}

export interface ReporteHorasExtraCreateDto extends Omit<ReporteHorasExtra, 'id'>{

}

export interface ReporteHorasExtraUpdateDto extends Omit<ReporteHorasExtra, 'empleado'>{

}
