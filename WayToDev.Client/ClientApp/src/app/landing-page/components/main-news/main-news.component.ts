import { Component, OnInit } from '@angular/core';
import { NewsShortInfo } from 'src/app/models/newsShortInfo';
import { ChatService } from 'src/app/services/chat.service';

@Component({
  selector: 'app-main-news',
  templateUrl: './main-news.component.html',
  styleUrls: ['./main-news.component.css']
})
export class MainNewsComponent implements OnInit {
  newsList: NewsShortInfo[] = [
    {
      id : "sdadas",
      title : "Hello from maks, this is the best title!",
      text: "Hello from maks, this is the best title! Hello from maks, this is the best title! Hello from maks, this is the best title! Hello from maks, this is the best title!"
    }
  ];
  constructor() {
    for (let index = 0; index < 5; index++) {
      this.newsList.push(this.newsList[0]);
    }
  }

  ngOnInit(): void {
  }
}
