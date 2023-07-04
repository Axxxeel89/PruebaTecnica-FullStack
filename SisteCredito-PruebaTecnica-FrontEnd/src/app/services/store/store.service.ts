import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs'
import { usuarios } from 'src/app/Models/usuarios';


@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private usuarioLogin:usuarios | null = {  //-> Creamos e inicializamos un objeto vacio
    id: '',
    Nombres: '',
    Apellidos: '',
    rol: '',
    email: '',
    userName: '',
    token: '',
    password: ''
  }

  private usuarioLogueado = new BehaviorSubject<usuarios |null>(this.usuarioLogin)
  usuarioLoogueado$ = this.usuarioLogueado.asObservable();

  constructor(
  ) { }

  guardarUsuarioLogueado(data: usuarios){
    this.usuarioLogin = data
    this.usuarioLogueado.next(this.usuarioLogin);

    const now = new Date();
    const tiempoExpiracion: number = 8 * 60 * 60
    const expirationDate = new Date(now.getTime() + tiempoExpiracion * 1000); // tiempoExpiracion en segundos

    const usuarioData = {
      usuario: this.usuarioLogin,
      expiration: expirationDate.getTime()
    };

    localStorage.setItem('SesionUsuario', JSON.stringify(usuarioData));

    // Establecer el tiempo de expiración
    setTimeout(() => {
      this.logout();
    }, tiempoExpiracion * 1000);
  }

  logout() {
    this.usuarioLogin = null;
    this.usuarioLogueado.next(null);
    localStorage.removeItem('SesionUsuario');
  }



}



