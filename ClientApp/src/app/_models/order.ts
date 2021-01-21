import { IAddress } from "./address";

export interface IOrderToCreate {
  basketId: string;
  orderMethodId: number;
  orderAddress: IAddress;
}

export interface IOrder {
  id: number;
  buyerEmail: string;
  orderDate: string;
  orderAddress: IAddress;
  orderMethod: string;
  orderMethodPrice: number;
  orderItems: IOrderItem[];
  subtotal: number;
  total: number;
  status: number;
}

export interface IOrderItem {
  productId: number;
  productName: string;
  pictureUrl: string;
  price: number;
  quantity: number;
}

