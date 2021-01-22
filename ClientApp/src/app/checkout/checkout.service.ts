import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IOrderMethod } from '../_models/ordeMethod';
import { IOrderToCreate } from '../_models/order';


@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOrderMethods() {
    return this.http.get(this.baseUrl + 'orders/orderMethods').pipe(
      map((om: IOrderMethod[]) => {
        return om.sort((a, b) => b.price - a.price);
      })
    );
  }

  creatOrder(order: IOrderToCreate) {
    return this.http.post(this.baseUrl + 'orders', order);

  }

}
