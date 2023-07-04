  import { Component, OnInit } from '@angular/core';
  import { FormControl, Validators, FormGroup } from '@angular/forms';
  import { Router} from '@angular/router'
  import { AuthService } from 'src/app/services/auth/auth.service';
  import { StoreService } from 'src/app/services/store/store.service';
  import { usuariosLoginDto } from 'src/app/Models/usuarios';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form = new FormGroup ({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  })

  loginFail:boolean = false;
  token: string = '';

  constructor(
    private authService:AuthService,
    private storeService:StoreService,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.emailField?.valueChanges
    .subscribe(rta => {
      this.loginFail = false
    })
  }

  Login(event: Event){
    const data:usuariosLoginDto = {
      email: this.form.value.email!,
      password: this.form.value.password!
    }

    this.authService.login(data)
    .subscribe({ next: (rta) => {
      this.storeService.guardarUsuarioLogueado(rta)
      this.router.navigate(['/home'])
    }, error: (error) => {
      console.log(error)
      this.loginFail = true;
    }})
  }

  get emailField(){
    return this.form.get('email');
  }

  get passwordField(){
    return this.form.get('password');
  }



}
