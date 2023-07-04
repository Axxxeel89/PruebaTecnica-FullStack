import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  user: string = '';
  usuarioSesion: any = null;
  usuario: string = '';

  constructor(
    private router:Router
  ) { }

  ngOnInit(): void {
    const usuarioString = localStorage.getItem('SesionUsuario');

    if(usuarioString)
    {
      this.usuarioSesion = JSON.parse(usuarioString);
      this.usuario = this.usuarioSesion.usuario.email;
      this.user = this.usuarioSesion.usuario.rol;
      console.log(this.user)
    }
  }

  LogOut(){
    localStorage.removeItem('SesionUsuario')
    this.router.navigate(["login"])
  }

}
