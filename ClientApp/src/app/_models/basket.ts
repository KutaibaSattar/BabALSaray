import {v4 as uuidv4} from 'uuid';
export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export interface IBasketItem {
  id: number;
  productName: string;
  price: number;
  quantity: number;
  pictureUrl: string;
  brand: string;
  type: string;
}

export class Basket implements IBasket {  // for generation unique Id
    id = uuidv4();
    items:  IBasketItem[] = [];
}

export interface IBasktTotals {
  service: number;
  subtotal: number;
  total: number;

}

/* function randomIntFromInterval(min, max) { // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min);
  }
 */
