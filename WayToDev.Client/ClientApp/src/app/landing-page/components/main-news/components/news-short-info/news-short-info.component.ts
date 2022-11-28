import { Component, Input, OnInit } from '@angular/core';
import { NewsShortInfo } from 'src/app/models/newsShortInfo';

@Component({
  selector: 'app-news-short-info',
  templateUrl: './news-short-info.component.html',
  styleUrls: ['./news-short-info.component.css']
})
export class NewsShortInfoComponent implements OnInit {
  @Input() news!: NewsShortInfo;
  constructor() { }

  ngOnInit(): void {

  }

}
