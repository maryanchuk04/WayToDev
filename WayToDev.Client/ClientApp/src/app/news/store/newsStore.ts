import {News} from "../models/news";
import {PaginationResponseModel} from "../../models/paginationResponseModel";

export interface NewsStore{
  news: PaginationResponseModel<News[]> | null
  previewNews: News[] | []
}
