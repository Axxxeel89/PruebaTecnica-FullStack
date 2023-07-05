import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { usuarios, usuariosLoginDto, usuarioRegisterDto } from 'src/app/Models/usuarios';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private API_URL: String = `${environment.API_URL}/Usuarios`

  constructor(
    private http: HttpClient
  ) { }

  login(usuariosLoginDto: usuariosLoginDto){
    return this.http.post<usuarios>(`${this.API_URL}/Login`, usuariosLoginDto);
  }

  register(usuarioRegisterDto:usuarioRegisterDto){
    return this.http.post<usuarios>(`${this.API_URL}/Registrar`, usuarioRegisterDto);
  }


}
