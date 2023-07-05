import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms'
import { usuarios, usuarioRegisterDto } from 'src/app/Models/usuarios';
import { AuthService } from 'src/app/services/auth/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form = new FormGroup({
    nombres: new FormControl('', Validators.required),
    apellidos: new FormControl('', Validators.required),
    rol: new FormControl('', Validators.required),
    username: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$/)])
  })

  correoExiste: boolean = false;

  constructor(
    private authService:AuthService,
  ) { }

  ngOnInit(): void {
  }


  register(event: Event){
    const datos: usuarioRegisterDto = {
      nombres: this.form.value.nombres!,
      apellidos: this.form.value.apellidos!,
      rol: this.form.value.rol!,
      userName:  this.form.value.username!,
      email:  this.form.value.email!,
      password:  this.form.value.password!,
    }

    this.authService.register(datos)
    .subscribe({ next: (response) => {
          console.log(response)
    }, error: (response) => {
      this.correoExiste = response.error.errores.mensaje;
  }})
  }


  get nombresField(){
    return this.form.get('nombres')
  }

  get apellidosField(){
    return this.form.get('apellidos')
  }

  get usernameField(){
    return this.form.get('username')
  }

  get rolField(){
    return this.form.get('rol')
  }

  get emailField(){
    return this.form.get('email')
  }

  get passwordField(){
    return this.form.get('password')
  }

}
