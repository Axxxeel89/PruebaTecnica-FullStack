import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  datoUsuario:any = null ;
  UsuarioLogueado: string = ''

  constructor() { }

  ngOnInit(): void {
    this.datoUsuario = localStorage.getItem('SesionUsuario');
    this.datoUsuario = JSON.parse(this.datoUsuario);
    if(this.datoUsuario)
    {
      this.UsuarioLogueado = this.datoUsuario.usuario.email;
    }
  }

}
