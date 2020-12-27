import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../_modules/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [
    ShopComponent, ProductItemComponent,
    ProductDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule,
  ],

  /*
  No need for export because we ake lazy loading and removed ShopComponent from app.module
  exports : [
    ShopComponent,

  ] */

})
export class ShopModule { }
