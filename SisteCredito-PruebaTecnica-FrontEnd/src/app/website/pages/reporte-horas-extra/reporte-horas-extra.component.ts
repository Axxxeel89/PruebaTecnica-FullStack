import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reporte-horas-extra',
  templateUrl: './reporte-horas-extra.component.html',
  styleUrls: ['./reporte-horas-extra.component.scss']
})
export class ReporteHorasExtraComponent implements OnInit {

  displayedColumns = [];
  dataSource = []

  constructor() { }

  ngOnInit(): void {
  }

  applyFilter(event: Event){

  }

}
