import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { Leader, LeaderDtoCreate, LeaderDtoUpdate } from 'src/app/Models/leader';

@Injectable({
  providedIn: 'root'
})
export class LeaderService {

  private API_URL: string= `${environment.API_URL}/Lideres`

  constructor(
    private http:HttpClient
  ) { }

  getAllLeaders(){
    return this.http.get<Leader[]>(this.API_URL)
  }

  getLederById(id:string){
    return this.http.get<Leader>(`${this.API_URL}/${id}`)
  }

  createLeader(leader: LeaderDtoCreate){
    return this.http.post<Leader>(`${this.API_URL}/`, leader)
  }

  updateLeader(id:string, leader: LeaderDtoUpdate){
    return this.http.put<Leader>(`${this.API_URL}/${id}`, leader)
  }

  deleteLeader(id:string){
    return this.http.delete<Leader>(`${this.API_URL}/${id}`)
  }
}
