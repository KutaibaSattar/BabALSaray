import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { User } from '../_models/user';
import { AccountService } from './../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
 
  constructor (private accountService : AccountService){}
 
  ngOnInit(){
    this.setCurrentUser();
 
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
