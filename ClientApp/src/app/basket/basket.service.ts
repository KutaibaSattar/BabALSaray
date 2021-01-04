import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasktTotals } from '../_models/basket';
import { IProduct } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  
  private basketsource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketsource.asObservable();

  private basketTotalSource = new BehaviorSubject<IBasktTotals>(null);
  basketTotal$ = this.basketTotalSource.asObservable();



  constructor(private http: HttpClient) { }

  /*Good place to do any initialization is in our roots component for our application and that's our
    app component.*/
  getBasket(id: string){

    return this.http.get(this.baseUrl + 'basket?id=' + id)
    .pipe (
      map((basket: IBasket) => {

        this.basketsource.next(basket);
        this.calculateTotals();

      })
    );
    

  }
  setBasket (basket: IBasket){
      return this.http.post(this.baseUrl + 'basket',basket ).subscribe((response: IBasket) =>{
        this.basketsource.next(response);
      this.calculateTotals();

      }, error => {console.log(error);
      
      })
  }

  getCurrentBasketValue(){
    return this.basketsource.value;

  }

  addItemToBasket(item: IProduct, quantity = 1){

    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem (basket.items,itemToAdd, quantity);
    this.setBasket(basket);
  }
  
  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
   /*  B in this case represents the item and each item has a price and the quantity.
      And we're multiplying that together and then we're adding it to a now a represents the number the results
      that we're returning from this produce function so.
      And a is given an initial value here of zero.
      So we start at zero we go to item 1 we times its price by its quantity and then we add it to a which
      becomes whatever that is. */
    const subtotal = basket.items.reduce((a,b) => (b.price * b.quantity) + a,0 );
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping,total,subtotal});

  }
  
  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex( i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd)
    }else{
      items[index].quantity += quantity;
    }
    return items;

  }
 
  private createBasket(): IBasket {
   const basket = new Basket();
   localStorage.setItem('basket_id', basket.id); //local storage for each browser
   return basket; 
  }
 
  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return{
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity, // same name so we dont need to maping
      brand: item.productBrand,
      type: item.productType
    }
  }
}
