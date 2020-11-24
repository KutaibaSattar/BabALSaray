import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { User } from '../_models/user';
import { AccountService } from './../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  users : any;
  title : 'Bab ALSaray Project'
  registerMode = false;
 
  constructor (private http: HttpClient,private accountService : AccountService){}
 
  ngOnInit(){
    this.getUsers();
    this.setCurrentUser();
 
   }
 
   getUsers(){
     this.http.get('/api/users').subscribe(Response=>{
       this.users = Response
 
    },err=>{console.log(err)})
 
   }

   setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
   }
   
  resgisterToggle() {

    this.registerMode = !this.registerMode

  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;


 }
 
 }
