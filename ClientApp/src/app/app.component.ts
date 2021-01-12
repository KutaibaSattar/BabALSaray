import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from './basket/basket.service';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {   // onInite is lifecycle

  constructor(private basketService: BasketService, private router: Router,private accountService: AccountService) {}

  ngOnInit() {

    this.loadBasket();
    this.setCurrentUser();
   
  }

  loadBasket(){
    const basketId = localStorage.getItem('basket_id');
     if (basketId) {
 
       this.basketService.getBasket(basketId).subscribe(() => {
         console.log('initialized basket');
 
       }, error => {console.log(error); });
 
       this.router.navigateByUrl('/home');
 
     }
 }

 setCurrentUser() {
  const user: User = JSON.parse(localStorage.getItem('user'));
  this.accountService.setCurrentUser(user);
 }
  
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



