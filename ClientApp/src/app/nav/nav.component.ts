import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from '../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../_models/basket';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
basket$: Observable<IBasket>;
currentUser$: Observable<User>;
// loggedIn : boolean

constructor(public accountService: AccountService, private router: Router, private basketService: BasketService ) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    this.currentUser$ = this.accountService.currentUser$;
    this.basket$ = this.basketService.basket$;
  }

  login() {
    this.accountService.login(this.model).subscribe(() => {this.router.navigateByUrl('/shop');
   });

  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/home');

  }

  /* getCurrentUser(){

      this.accountService.currentUser$.subscribe(user =>{
        this.loggedIn= !!user; // double !! transfer object to boolean

      }, error=> { console.log(error);})

  } */

}
