import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {   // onInite is lifecycle

  constructor(private basketService: BasketService, private router: Router) {}

  ngOnInit() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {

      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialized basket');

      }, error => {console.log(error); });

      this.router.navigateByUrl('/home');

    }
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



