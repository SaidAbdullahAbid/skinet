import { IProduct } from './../../shared/models/product';
import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'skinet-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input("Product") product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
