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
  title = 'app';
  products: IProduct[];

  constructor( private http: HttpClient, private accountSrvice: AccountService) {}

  ngOnInit() {

    this.http.get('https://localhost:5001/api/products').subscribe((rseponse: IPagination) => {

    this.products = rseponse.data;
    console.log(this.products);

    });

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


}
