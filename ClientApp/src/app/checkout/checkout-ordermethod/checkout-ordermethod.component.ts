import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BasketService } from 'src/app/basket/basket.service';
import { IOrderMethod } from 'src/app/_models/ordeMethod';
import { CheckoutService } from '../checkout.service';


@Component({
  selector: 'app-checkout-ordermethod',
  templateUrl: './checkout-ordermethod.component.html',
  styleUrls: ['./checkout-ordermethod.component.css']
})
export class CheckoutOrdermethodComponent implements OnInit {
@Input() checkoutForm: FormGroup; 
orderMethod: IOrderMethod[];
  constructor(private checkoutService: CheckoutService, private basketService : BasketService) { }

  ngOnInit(): void {
    this.checkoutService.getOrderMethods().subscribe((dm: IOrderMethod[]) =>{
      this.orderMethod = dm;

    }, error =>
    {
      console.log(error);

    })
  }

  setServicePrice(orderMethod: IOrderMethod){
    this.basketService.setServicePrice(orderMethod);
  }

}
