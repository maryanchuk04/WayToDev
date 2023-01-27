import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { NewsService } from './news.service';
import { mockOneNews, mockPaginationNewsArray } from 'src/app/mocks/news-mocks';
import { NewsFilterModel } from '../models/newsFilterModel';

describe('News Service Tests', () => {
  let service: NewsService;
  let httpController: HttpTestingController;

  let url = 'https://localhost:7218/api';

  //set up test
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(NewsService);
    httpController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    const service: NewsService = TestBed.get(NewsService);

    expect(service).toBeTruthy();
  });

  it('should return news', () => {
    //Arrange
    const id = '1';

    //Act
    service.getNewsById(id).subscribe(data => {
      //Assert
      expect(data).toEqual(mockOneNews)
    });

    const req = httpController.expectOne({
      method: 'GET',
      url: `${url}/news/${id}`,
    });

    req.flush(mockOneNews);
  });

  it('should return expected news array', () => {
    //Arrange
    const newsFilterModel: NewsFilterModel = {
      page: 1,
      pageSize: 1,
      searchWord: '',
      sortBy: 0
    };

    //Act
    service.getNews(newsFilterModel).subscribe(data => {
      //Assert
      expect(data).toEqual(mockPaginationNewsArray);
    });

    const req = httpController.expectOne({
      method: "GET",
      url: `${url}/news?Page=${newsFilterModel.page}&PageSize=${newsFilterModel.pageSize}&SearchWord=${newsFilterModel.searchWord}&SortBy=${newsFilterModel.sortBy}`
    })

    req.flush(mockPaginationNewsArray);
  });
});
