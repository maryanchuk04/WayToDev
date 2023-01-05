import {AfterViewInit, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {AppState} from "../../../store/appState";
import {select, Store} from "@ngrx/store";
import {debounceTime, distinctUntilChanged, distinctUntilKeyChanged, fromEvent, Observable, tap} from "rxjs";
import {News} from "../../models/news";
import {getNews} from "../../store/news.actions";
import {newsSelector} from "../../store/news.selectors";
import {PaginationResponseModel} from "../../../models/paginationResponseModel";
import {PaginationInstance} from "ngx-pagination";

@Component({
  selector: 'app-all-news-page',
  templateUrl: './all-news-page.component.html',
  styleUrls: ['./all-news-page.component.css']
})
export class AllNewsPageComponent implements OnInit, AfterViewInit {
  news$: Observable<PaginationResponseModel<News[]>|null>;
  public config: PaginationInstance;
  searchField: string;
  @ViewChild('search') searchInput: ElementRef;

  constructor(private store: Store<AppState>) {
    this.dispatchNews(1);
  }

  ngOnInit(): void {
    this.news$.subscribe(_=>{
      if(_ != null) {
        console.log(_)
        this.config = {
          itemsPerPage: 9,
          currentPage: _.pageViewModel.pageNumber || 1,
          totalItems: _.pageViewModel.totalItemsCount
        };
      }
    })
  }

  onPageChange(pageNumber: number){
    console.log(pageNumber);
    this.config.currentPage = pageNumber;
    this.dispatchNews(pageNumber);
  }

  private dispatchNews(page: number, searchText: string = ""){
    this.store.dispatch(getNews({
      filter: {
        page: page,
        pageSize: 9,
        searchWord: searchText,
        sortBy: 0
      }
    }))
    this.news$ = this.store.pipe(select(newsSelector))
  };

  search(){
    console.log(this.searchField)
  }

  ngAfterViewInit(): void {
    fromEvent(this.searchInput.nativeElement, "keyup")
      .pipe(
        debounceTime(1000),
        distinctUntilChanged(),
        tap(()=>{
          if(this.searchInput.nativeElement.value.trim() == ""){
            this.dispatchNews(1);
          }
          console.log(this.searchInput.nativeElement.value)
          this.dispatchNews(1, this.searchInput.nativeElement.value.trim());
        })
      )
      .subscribe();
  }
}
