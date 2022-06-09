import { ShopParams } from './../shared/models/shopParams';
import { IBrand } from './../shared/models/brand';
import { IType } from './../shared/models/productType';
import { ShopService } from './shop.service';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { forkJoin } from 'rxjs';
import { IPagination } from '../shared/models/pagination';

@Component({
  selector: 'skinet-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild("search", { static: false }) searchTerm: ElementRef;
  products: IProduct[];
  types: IType[];
  brands: IBrand[];
  shopParams: ShopParams = new ShopParams();
  sortOptions: {
    name: string,
    value: string
  }[] = [
      { name: "Alphabetical", value: "name" },
      { name: "Price: From low to hight", value: "priceAsc" },
      { name: "Price: From hight to low", value: "priceDesc" }
    ]
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    var requestToServe = [
      this.shopService.getProduct(this.shopParams),
      this.shopService.getBrand(),
      this.shopService.getType(),
    ];
    forkJoin(requestToServe).subscribe({
      next: (result: any) => {
        this.products = result[0].data;
        this.brands = [{ 'id': 0, name: 'All' }, ...result[1]];
        this.types = [{ 'id': 0, name: 'All' }, ...result[2]];
        this.setShopPramsForProducts(result[0]);
      },
      error: (error: Error) => {
        console.log(error);
      }
    })
  }
  getProducts() {
    this.shopService.getProduct(
      this.shopParams
    ).subscribe({
      next: (pagination: IPagination) => {
        this.products = pagination.data;
        this.setShopPramsForProducts(pagination);
      },
      error: (error: Error) => {
        console.log(error);
      }
    })
  }

  onBrandIdSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onTypeIdSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onSortValueSelected(value: string) {
    this.shopParams.sort = value;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.getProducts();
  }
  onPageChange(event: number) {
    if (this.shopParams.pageIndex !== event) {
      this.shopParams.pageIndex = event;
      this.getProducts();
    }
  }
  onReset() {
    this.shopParams = new ShopParams();
    this.searchTerm.nativeElement.value = null;
    this.getProducts();
  }
  private setShopPramsForProducts(pagination: IPagination) {
    this.shopParams.pageIndex = pagination.pageIndex;
    this.shopParams.pageSize = pagination.pageSize;
    this.shopParams.totalCount = pagination.count;
  }

}
