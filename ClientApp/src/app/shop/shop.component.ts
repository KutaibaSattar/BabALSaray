import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../_models/brand';
import { IProduct } from '../_models/product';
import { IType } from '../_models/producttype';
import { ShopParams } from '../_models/shopParams';
import { ShopService } from '../_services/shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  totalCount: number;
  shopParams =  new ShopParams();
  sortOptions = [
    {name: 'Alphabet', value: 'name'},
    {name: 'Price: Low to High', value: 'PriceAsc'},
    {name: 'Price: High to Low', value: 'PriceDesc'},
  ];
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();


  }

  getProducts() {
      // if need only response then no need to use pipe
      this.shopService.getProducts(this.shopParams,this.shopParams.pageNumber,6).subscribe(res => {
    /*   this.products = res.data;
      this.shopParams.pageNumber = res.pageIndex;
      this.shopParams.pageSize = res.pageSize;
      this.totalCount = res.count; */
      this.products = res.result;
      this.shopParams.pageNumber = res.pagination.currentPage;
      this.shopParams.pageSize = res.pagination.itemsPerPage;
      this.totalCount = res.pagination.totalItems;

      }, error => {console.log(error); });
  }
  /*
  Now the response is an array of brand objects.
  And what we're doing is creating anethor object to add to this array.
  And when we use this spread operator it spreads all of the objects from that array and is simply adding
  on and other objects at the front here which is named all.
  */

  getBrands() {
    this.shopService.getBrands().subscribe(res => {
      this.brands = [{id: 0, name: 'All'}, ...res] ; // spread operator
      }, error => {console.log(error); });
  }
  getTypes() {
    this.shopService.getTypes().subscribe(res => {
      this.types =  [{id: 0, name: 'All'}, ...res] ;
      }, error => {console.log(error); });
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();

    }

  }

  OnSearch() {

    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '' ;
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
