import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'skinet-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrls: ['./pagination-header.component.scss']
})
export class PaginationHeaderComponent implements OnInit {
  @Input("TotalCount") totalCount: number;
  @Input("PageIndex") pageIndex: number;
  @Input("PageSize") pageSize: number;
  constructor() { }

  ngOnInit(): void {
  }

}
