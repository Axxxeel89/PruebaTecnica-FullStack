import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ReporteHorasExtraComponent } from './pages/reporte-horas-extra/reporte-horas-extra.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ReporteHorasExtraFormComponent } from './reporte-horas-extra-form/reporte-horas-extra-form/reporte-horas-extra-form.component';
import { AuthGuard } from '../guard/auth/auth.guard';


const routes: Routes = [
  {
    path:'',
    component: LayoutComponent,
    children:[
      {
        path:'',
        redirectTo: 'login',
        pathMatch: 'full'
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'home',
        canActivate: [AuthGuard],
        component: HomeComponent
      },
      {
        path: 'reporte-horas-extra',
        canActivate: [AuthGuard],
        component: ReporteHorasExtraComponent
      },
      {
        path: 'reporte-horas-extra-form',
        canActivate: [AuthGuard],
        component: ReporteHorasExtraFormComponent
      },
      {
        path: 'reporte-horas-extra-form/:id',
        canActivate: [AuthGuard],
        component: ReporteHorasExtraFormComponent
      },
      {
        path: 'contact',
        canActivate: [AuthGuard],
        component: ContactComponent
      }
    ]

  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebsiteRoutingModule { }
