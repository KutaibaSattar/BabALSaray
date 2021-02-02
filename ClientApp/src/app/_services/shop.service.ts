import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBrand } from '../_models/brand';
import { Pagination, PaginatedResutlt } from '../_models/pagination';
import { IProduct } from '../_models/product';
import { IType } from '../_models/producttype';
import { ShopParams } from '../_models/shopParams';
/* So our services are singletons which means they're always available as long as our app is available.
They're not like components where angular is going to initialize them and then destroy them as soon
as we move away from the component.
This is always going to be available for it's an excellent place to hold data.
Look we need to share across the application and it's also a very good place to inject our HTTP service */

@Injectable({
  providedIn: 'root'
})
export class ShopService {
 
  baseUrl = environment.apiUrl
  

  constructor(private http: HttpClient) { }

  paginatedResult: PaginatedResutlt<IProduct[]> =  new PaginatedResutlt<IProduct[]>();
  


  getProducts( shopParams: ShopParams , page?: number, itemsPerPage?: number) {

   
      
    let params = new HttpParams();

      if(page !==null && itemsPerPage !== null){
        params = params.append('pageNumber',page.toString() )
        params = params.append('pageSize',itemsPerPage.toString() )
      }
    
  

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());

    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());

    }

    if (shopParams.search) {
     params = params.append('search', shopParams.search);

    }

     params = params.append('sort', shopParams.sort); // no need for if statement because he default is 'name'

     params = params.append('pageIndex', shopParams.pageNumber.toString());

     params = params.append('pageSize', shopParams.pageSize.toString() );

 /* When we use  return this.http.get<IPagination[]>(this.baseUrl + 'products').Pipe(), give us only resposne body
    When we observing the response and use (params) then we get full response not only bode like headers, ....
    
    */
    return this.http.get<IProduct[]>(this.baseUrl + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
       this.paginatedResult.result =  response.body;
       if (response.headers.get('Pagination') !== null){
       this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
       }
       return this.paginatedResult;
      })
    );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);

  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}
