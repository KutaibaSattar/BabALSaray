import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from '../_models/brand';
import { IPagination } from '../_models/pagination';
import { IType } from '../_models/producttype';
/* So our services are singletons which means they're always available as long as our app is available.
They're not like components where angular is going to initialize them and then destroy them as soon
as we move away from the component.
This is always going to be available for it's an excellent place to hold data.
Look we need to share across the application and it's also a very good place to inject our HTTP service */

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number, sort?: string ) {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());

    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());

    }

    if (sort) {
     params = params.append('sort', sort);

    }

 /* Now this syntax might look a little bit strange if it's the first time you've encountered it this pipe
is a wrapper around any are extra x operators that we want to use.
And inside this pipe method we can chain as many our exchange operators as we want inside this request
for instance if I wanted to delay the response coming back from for whatever reason that I could at
delay which is never our exchange as operator and then I could specify an amount of time to delay the
response and add a comma and chain the response onto it.
And I would also need to add the delay inside here as well.
But this pipe method just allows us to chain multiple our extraneous operators together to manipulate
or do something with the observable as it comes back in.
    */
    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}
