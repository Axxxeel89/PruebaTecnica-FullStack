import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { Empleados, EmpleadoUpdateDto, EmpleadosCreateDto } from 'src/app/Models/empleados';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  private API_URL: string= `${environment.API_URL}/Empleados`

  constructor(
    private http:HttpClient
  ) { }

  getAllEmployee(){
    return this.http.get<Empleados[]>(this.API_URL)
  }

  getEmployeeById(id:string){
    return this.http.get<Empleados>(`${this.API_URL}/${id}`)
  }

  createEmployee(employee: EmpleadosCreateDto){
    return this.http.post<Empleados>(`${this.API_URL}/`, employee)
  }

  updateEmployee(id:string, employee: EmpleadoUpdateDto){
    return this.http.put<Empleados>(`${this.API_URL}/${id}`, employee)
  }

  deleteEmployee(id:string){
    return this.http.delete<Empleados>(`${this.API_URL}/${id}`)
  }
}
