import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  datosUsuario: any = null;
  token: string = '';


  constructor(
    private router:Router
  ) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.datosUsuario = localStorage.getItem('SesionUsuario')
    this.datosUsuario = JSON.parse(this.datosUsuario)
    if(this.datosUsuario)
    {
      this.token = this.datosUsuario.usuario.token
    }

    if(!this.token ){ //-> Sino tiene un token redireccioname a home
      console.log("No puedes ingresar si no estas autenticado en la aplicación")
      this.router.navigate(['/login']) //--> Usando el router podemos indicar que queremos navegar a esa ruta, es como un redirecionamiento
      return false
    }
    return  true;
  }

}
