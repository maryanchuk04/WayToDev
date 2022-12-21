import { Component, OnInit, Input } from '@angular/core';
import { NewsListItem } from "../../../models/newsListItem"
@Component({
  selector: 'app-news-list-item',
  templateUrl: './news-list-item.component.html',
  styleUrls: ['./news-list-item.component.css']
})
export class NewsListItemComponent implements OnInit {
  @Input() news: NewsListItem;
  constructor() { }

  ngOnInit(): void {
  }
}
