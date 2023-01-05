import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {NewsFilterModel} from "../models/newsFilterModel";
import {News} from "../models/news";
import {Observable} from "rxjs";
import {PaginationResponseModel} from "../../models/paginationResponseModel";

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  url: string = `${environment.basePath}news`

  constructor(private http: HttpClient) {
  }

  getNews(newsFilter: NewsFilterModel): Observable<PaginationResponseModel<News[]>> {
    return this.http.get<PaginationResponseModel<News[]>>(
      `${this.url}?Page=${newsFilter.page}&PageSize=${newsFilter.pageSize}&SearchWord=${newsFilter.searchWord}&SortBy=${newsFilter.sortBy}`)
  }

  getNewsById(id: string): Observable<News>{
    return this.http.get<News>(`${this.url}/${id}`)
  }
}
