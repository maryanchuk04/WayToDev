import {Component, OnInit} from '@angular/core';
import {NewsShortInfo} from 'src/app/models/newsShortInfo';
import {Store} from "@ngrx/store";
import {AppState} from "../../../store/appState";
import * as NewsActions from '../../../../app/news/store/news.actions'
import {Observable} from "rxjs";
import {News} from "../../../news/models/news";
import {select} from "@ngrx/store";
import {newsPreviewSelector, newsSelector} from "../../../news/store/news.selectors";

@Component({
  selector: 'app-main-news',
  templateUrl: './main-news.component.html',
  styleUrls: ['./main-news.component.css']
})
export class MainNewsComponent implements OnInit {
  news$: Observable<News[]>;

  constructor(private store: Store<AppState>) {
    this.store.dispatch(NewsActions.getPreviewNews({
      filter: {
        page: 1,
        pageSize: 6,
        searchWord: "",
        sortBy: 0
      }
    }));
  }

  ngOnInit(): void {
    this.news$ = this.store.pipe(select(newsPreviewSelector))
  }

}
