import {Component, OnDestroy, OnInit} from '@angular/core';
import {News} from "../../models/news";
import {ActivatedRoute} from "@angular/router";
import {NewsService} from "../../services/news.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-news-page',
  templateUrl: './news-page.component.html',
  styleUrls: ['./news-page.component.css']
})
export class NewsPageComponent implements OnInit, OnDestroy {
  news: News;
  routerSub: Subscription;
  constructor(private router: ActivatedRoute, private newsService: NewsService) { }

  ngOnInit(): void {
    this.routerSub = this.router.params.subscribe(params =>{
      this.newsService.getNewsById(params["id"]).subscribe(_=> this.news = _);
    })
  }

  ngOnDestroy(): void {
    this.routerSub.unsubscribe();
  }
}
