import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WebsiteRoutingModule } from './website-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { NavComponent } from './components/nav/nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ReporteHorasExtraComponent } from './pages/reporte-horas-extra/reporte-horas-extra.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ContactComponent } from './pages/contact/contact.component';
import { SharedModule } from '../shared/shared.module';

//Forms
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
 import {ReporteHorasExtraFormComponent} from './pages/reporte-horas-extra-form/reporte-horas-extra-form.component';


@NgModule({
  declarations: [
    HeaderComponent,
    NavComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    ReporteHorasExtraComponent,
    LayoutComponent,
    ContactComponent,
    ReporteHorasExtraFormComponent
  ],
  imports: [
    CommonModule,
    WebsiteRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebsiteModule { }
