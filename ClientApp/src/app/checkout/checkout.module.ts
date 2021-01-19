import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { CheckoutRoutingModule } from './checkout-routing.module';
import { share } from 'rxjs/operators';
import { SharedModule } from '../_shared/shared.module';




@NgModule({
  declarations: [CheckoutComponent],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule
    
  ],

})
export class CheckoutModule { }
