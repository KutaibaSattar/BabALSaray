import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './_models/product';
import { IPagination } from './_models/pagination';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {   // onInite is lifecycle

  constructor() {}

  ngOnInit() {}

    // this.getUsers();
    // this.setCurrentUser();
  }

 /*  setCurrentUser(){

    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountSrvice.setCurrentUser(user);

  } */

 /*  getUsers(){
    this.http.get('/api/users').subscribe(res => {
      this.users = res;},
      err =>{
        console.log(err);
      });


  } */



