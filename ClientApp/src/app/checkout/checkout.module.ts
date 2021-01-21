import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { CheckoutRoutingModule } from './checkout-routing.module';
import { share } from 'rxjs/operators';
import { SharedModule } from '../_shared/shared.module';
import { CheckoutAddressComponent } from './checkout-address/checkout-address.component';
import { CheckoutOrdermethodComponent } from './checkout-ordermethod/checkout-ordermethod.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';
import { CheckoutSuccessComponent } from './checkout-success/checkout-success.component';




@NgModule({
  declarations: [CheckoutComponent, CheckoutAddressComponent, CheckoutOrdermethodComponent,
     CheckoutReviewComponent, CheckoutPaymentComponent, CheckoutSuccessComponent],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule
    
  ],

})
export class CheckoutModule { }
