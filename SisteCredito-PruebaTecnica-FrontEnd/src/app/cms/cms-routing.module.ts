import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './pages/employee/employee.component';
import { LeaderComponent } from './pages/leader/leader.component';
import { LayoutComponent } from './components/layout/layout.component';
import { AdministracionComponent } from './pages/administracion/administracion.component';
import { RegisterComponent } from './pages/register/register.component';
import { LeaderFormComponent } from './pages/leader-form/leader-form.component';
import { EmployeeFormComponent } from './pages/employee-form/employee-form.component';
import { AuthGuard } from '../guard/auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children:[
      {
        path: '',
        redirectTo: 'administracion',
        pathMatch: 'full'
      },
      {
        path: 'administracion',
        canActivate: [AuthGuard],
        component: AdministracionComponent
      },
      {
        path: 'register',
        canActivate: [AuthGuard],
        component: RegisterComponent
      },
      {
        path: 'employee',
        canActivate: [AuthGuard],
        component: EmployeeComponent
      },
      {
        path: 'employee-form',
        canActivate: [AuthGuard],
        component: EmployeeFormComponent
      },
      {
        path: 'employee-form/:id',
        canActivate: [AuthGuard],
        component: EmployeeFormComponent
      },
      {
        path: 'leader',
        canActivate: [AuthGuard],
        component: LeaderComponent
      },
      {
        path: 'leader-form',
        canActivate: [AuthGuard],
        component: LeaderFormComponent
      },
      {
        path: 'leader-form/:id',
        canActivate: [AuthGuard],
        component: LeaderFormComponent
      },
      {
        path: '**',
        redirectTo: 'employee',
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CmsRoutingModule { }
