import { IPagination } from './models/pagination';
import { IProduct } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[] = [];
  constructor(private http: HttpClient) {
    this.http.get("https://localhost:5001/api/Products?pageSize=50")
      .subscribe((result: IPagination) => {
        this.products   = result.data;
      })
  }
  ngOnInit(): void {
  }
}
