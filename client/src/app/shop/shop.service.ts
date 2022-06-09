import { ShopParams } from './../shared/models/shopParams';
import { IBrand } from './../shared/models/brand';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from "rxjs/operators";
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private readonly BASEURL: string = "https://localhost:5001/api/";
  constructor(private http: HttpClient) {
  }
  getProduct(shopParams: ShopParams): Observable<IPagination> {
    var prams = new HttpParams();

    if (shopParams.brandId !== 0) prams = prams.append("brandId", shopParams.brandId);
    if (shopParams.typeId !== 0) prams = prams.append("typeId", shopParams.typeId);
    if (shopParams.search) prams = prams.append("search", shopParams.search);

    prams = prams.append("sort", shopParams.sort);
    prams = prams.append('PageIndex', shopParams.pageIndex);
    prams = prams.append('PageSize', shopParams.pageSize);

    return this.http.get<IPagination>(this.BASEURL + "Products", { observe: "response", params: prams }).pipe(
      map(response => {
        return response.body;
      })
    )
  }
  getBrand(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.BASEURL + "Products/brands");
  }
  getType(): Observable<IType[]> {
    return this.http.get<IType[]>(this.BASEURL + "Products/types");
  }
}
