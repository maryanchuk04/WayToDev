import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {NewsService} from "../services/news.service";
import * as NewsActions from './news.actions'
import {map, mergeMap} from "rxjs";
import {NewsFilterModel} from "../models/newsFilterModel";

@Injectable()
export class NewsEffects {
  constructor(private actions$: Actions, private newsService: NewsService) {
  }

  getNews$ = createEffect(() =>
    this.actions$.pipe(
      ofType(NewsActions.getNews),
      map(action => action.filter),
      mergeMap((filter: NewsFilterModel) =>
        this.newsService.getNews(filter).pipe(map((data) => NewsActions.getNewsSuccess({news: data}))
        )
      )
    )
  )

  getNewsPreview$ = createEffect(
    () => this.actions$.pipe(
      ofType(NewsActions.getPreviewNews),
      mergeMap(() =>
        this.newsService.getNews({
          page: 1,
          pageSize: 6,
          sortBy: 0,
          searchWord: ""
        }).pipe(map((data) => NewsActions.getPreviewNewsSuccess({news: data.items}))
        )
      )
    )
  )
}
