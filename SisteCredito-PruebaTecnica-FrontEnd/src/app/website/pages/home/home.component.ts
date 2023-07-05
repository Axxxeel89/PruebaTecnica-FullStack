import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  dato: any = null;
  token: string = '';
  constructor(
    private authService:AuthService
  ) { }

  ngOnInit(): void {
    const datoString = localStorage.getItem('SesionUsuario'); //-> Forma de texto

    if(datoString)
    {
      this.dato= JSON.parse(datoString)
      this.token = this.dato.usuario.token;
    }
  }

}
