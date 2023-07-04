import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CmsRoutingModule } from './cms-routing.module';
import { RegisterComponent } from './pages/register/register.component';
import { HeaderComponent } from './components/header/header.component';
import { LayoutComponent } from './components/layout/layout.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { LeaderComponent } from './pages/leader/leader.component';
import { AdministracionComponent } from './pages/administracion/administracion.component';
import { SharedModule } from '../shared/shared.module';
import { LeaderFormComponent } from './pages/leader-form/leader-form.component';
import { EmployeeFormComponent } from './pages/employee-form/employee-form.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RegisterComponent,
    HeaderComponent,
    LayoutComponent,
    EmployeeComponent,
    LeaderComponent,
    AdministracionComponent,
    LeaderFormComponent,
    EmployeeFormComponent
  ],
  imports: [
    CommonModule,
    CmsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CmsModule { }
