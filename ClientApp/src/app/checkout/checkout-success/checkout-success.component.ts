import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrder } from 'src/app/_models/order';

@Component({
  selector: 'app-checkout-success',
  templateUrl: './checkout-success.component.html',
  styleUrls: ['./checkout-success.component.css']
})
export class CheckoutSuccessComponent implements OnInit {
 /*  we need to get our navigation extras inside our construct

  to here. We won't have it if we try and do this inside our ngOnInit. */
  order: IOrder;
  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;
    if (state) {
     this.order = state as IOrder;

    }
   }

  ngOnInit(): void {
  }

}
