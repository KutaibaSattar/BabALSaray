import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { dbAccounts } from '../_models/adaccounts';


//code changed be adding jwt.interceptor
const httpOptions = {
headers: new HttpHeaders({
  Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token

})

} 

@Injectable({
  providedIn: 'root'
})
export class DbaccountsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getdbAccounts(){
    
   //return this.http.get<dbAccounts[]>(this.baseUrl + 'dbaccounts', httpOptions);
   return this.http.get<dbAccounts[]>(this.baseUrl + 'dbaccounts');

  }

  getdbAccount(accountid: number){
 // return this.http.get<dbAccounts>(this.baseUrl + 'dbaccounts/' + accountid , httpOptions);
  return this.http.get<dbAccounts>(this.baseUrl + 'dbaccounts/' + accountid)
  }



}
