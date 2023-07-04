import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ReporteHorasExtraComponent } from './pages/reporte-horas-extra/reporte-horas-extra.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ReporteHorasExtraFormComponent } from './reporte-horas-extra-form/reporte-horas-extra-form/reporte-horas-extra-form.component';


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
        component: HomeComponent
      },
      {
        path: 'reporte-horas-extra',
        component: ReporteHorasExtraComponent
      },
      {
        path: 'reporte-horas-extra-form',
        component: ReporteHorasExtraFormComponent
      },
      {
        path: 'reporte-horas-extra-form/:id',
        component: ReporteHorasExtraFormComponent
      },
      {
        path: 'contact',
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
