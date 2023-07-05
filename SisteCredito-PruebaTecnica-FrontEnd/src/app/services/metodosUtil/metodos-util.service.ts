import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { generos, areas, Estados, DDLlideres } from 'src/app/Models/MetodosUtilitarios';
import { DDLEmpleados } from 'src/app/Models/empleados';

@Injectable({
  providedIn: 'root'
})
export class MetodosUtilService {

  private API_URL = `${environment.API_URL}/MetodosUtilitarios`

  constructor(
    private http: HttpClient
  ) { }

  getAreas(){
    return this.http.get<areas[]>(`${this.API_URL}/DDLAreas`)
  }

  getGeneros(){
    return this.http.get<generos[]>(`${this.API_URL}/DDLGeneros`)
  }

  getEmpleados(){
    return this.http.get<DDLEmpleados[]>(`${this.API_URL}/DDLEmpleados`)
  }

  getEstados(){
    return this.http.get<Estados[]>(`${this.API_URL}/DDLEstadosReporte`)
  }

  getLideres(){
    return this.http.get<DDLlideres[]>(`${this.API_URL}/DDLLideres`)
  }


}
