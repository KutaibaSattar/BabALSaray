import { Component, OnInit } from '@angular/core';
import { IBrand } from '../_models/brand';
import { IProduct } from '../_models/product';
import { IType } from '../_models/producttype';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected  = 0;
  typeIdSelected  = 0;
  sortSelectrd = 'name';
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
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelectrd).subscribe(res => {
      this.products = res.data;
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
    this.brandIdSelected = brandId;
    this.getProducts();

  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();

  }

  onSortSelected(sort: string) {
    this.sortSelectrd = sort;
    this.getProducts();

  }

}
