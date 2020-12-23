import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../_models/pagination';
/* So our services are singletons which means they're always available as long as our app is available.
They're not like components where angular is going to initialize them and then destroy them as soon
as we move away from the component.
This is always going to be available for it's an excellent place to hold data.
Look we need to share across the application and it's also a very good place to inject our HTTP service */

@Injectable({
  providedIn: 'root' 
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getProducts(){

    return this.http.get<IPagination>(this.baseUrl + 'products')


  }

}
