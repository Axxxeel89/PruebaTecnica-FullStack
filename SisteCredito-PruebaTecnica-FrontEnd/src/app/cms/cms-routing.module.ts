import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './pages/employee/employee.component';
import { LeaderComponent } from './pages/leader/leader.component';
import { LayoutComponent } from './components/layout/layout.component';
import { AdministracionComponent } from './pages/administracion/administracion.component';
import { RegisterComponent } from './pages/register/register.component';
import { LeaderFormComponent } from './pages/leader-form/leader-form.component';
import { EmployeeFormComponent } from './pages/employee-form/employee-form.component';

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
        component: AdministracionComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'employee',
        component: EmployeeComponent
      },
      {
        path: 'employee-form',
        component: EmployeeFormComponent
      },
      {
        path: 'employee-form/:id',
        component: EmployeeFormComponent
      },
      {
        path: 'leader',
        component: LeaderComponent
      },
      {
        path: 'leader-form',
        component: LeaderFormComponent
      },
      {
        path: 'leader-form/:id',
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
