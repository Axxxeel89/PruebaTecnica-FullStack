import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReporteHorasExtra, ReporteHorasExtraCreateDto, ReporteHorasExtraUpdateDto } from 'src/app/Models/reporteHoraExtra';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class ReporteHorasService {

  private API_URL:string = `${environment.API_URL}/ReporteHorasExtra`


  constructor(
    private http:HttpClient
  ) { }

  getAllReportOvertime(usuarioLogueado: string){
    return this.http.get<ReporteHorasExtra[]>(`${this.API_URL}/nombreUsuario:string?nombreUsuario=${usuarioLogueado}`)
  }

  getReportOvertimeById(id:string){
    return this.http.get<ReporteHorasExtra>(`${this.API_URL}/${id}`)
  }

  createReportOvertime(report: ReporteHorasExtraCreateDto){
    return this.http.post<ReporteHorasExtra>(`${this.API_URL}`, report)
  }

  updateReportOvertime(id:string, report:ReporteHorasExtraUpdateDto){
    return this.http.put<ReporteHorasExtra>(`${this.API_URL}/${id}`, report)
  }

  deleteReportOvertime(id:string){
    return this.http.delete<ReporteHorasExtra>(`${this.API_URL}/${id}`)
  }

}
