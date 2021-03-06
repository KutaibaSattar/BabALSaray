import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/_models/basket';
import { IOrder } from 'src/app/_models/order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.css']
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm: FormGroup;

  constructor(private basketService: BasketService, private checkoutService: CheckoutService,
   private toastr: ToastrService, private router: Router ) { }



  ngOnInit(): void {
  }

  submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.OrderToCreate(basket);
    this.checkoutService.creatOrder(orderToCreate).subscribe( (order: IOrder) => {
      this.toastr.success('Order created successfully');
      this.basketService.deleteLocalBasket(basket.id);
      const navigationExtras: NavigationExtras  = {state: order};
      this.router.navigate(['checkout/success'], navigationExtras);
    }, error => {
      this.toastr.error(error.message);
      console.log(error);
    });
  }

 private OrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      orderMethodId : +this.checkoutForm.get('orderMethodForm').get('orderMethod').value,
      orderAddress : this.checkoutForm.get('addressForm').value,

    };

  }

}
