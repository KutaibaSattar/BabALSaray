import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  
  })}
  

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMenbers(){

   
    return this.http.get<User[]>(this.baseUrl + 'users', httpOptions);

  }

  getMember(userid : number){

    return this.http.get<User>(this.baseUrl + 'users', httpOptions)

  }

}
