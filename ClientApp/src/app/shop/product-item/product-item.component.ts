import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/_models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
 // this component is child of shopcomponet so we need using input properties of it's parent

export class ProductItemComponent implements OnInit {
@Input() product: IProduct;
  constructor() { }
  ngOnInit(): void {
  }

}
