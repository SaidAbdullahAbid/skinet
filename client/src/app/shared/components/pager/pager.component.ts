import { Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'skinet-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
  @Input("PageSize") pageSize: number;
  @Input("TotalCount") totalCount: number;
  @Output("PageChanged") pageChanged = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }
  onPagerChange($event: any) {
    this.pageChanged.emit($event.page);
  }
}
