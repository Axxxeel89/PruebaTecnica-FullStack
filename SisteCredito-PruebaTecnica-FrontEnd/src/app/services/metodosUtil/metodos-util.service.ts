import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { generos, areas } from 'src/app/Models/MetodosUtilitarios';

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


}
