import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() {}

  token: string = ''

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = this.addToken(request)
    return next.handle(request);
  }

  private addToken(request:HttpRequest<unknown>){
    let datoUsuario:any = localStorage.getItem('SesionUsuario');
    datoUsuario = JSON.parse(datoUsuario!)
    if(datoUsuario)
    {
      this.token= datoUsuario.usuario.token;
    }

    if(this.token){
      const authReq = request.clone({
        headers:request.headers.set( 'Authorization', `Bearer ${this.token}`,)
      });
      return authReq;
    }
    return request;

  }
}
