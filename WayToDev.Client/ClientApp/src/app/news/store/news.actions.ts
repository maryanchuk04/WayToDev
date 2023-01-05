import {createAction, props} from "@ngrx/store";
import {News} from "../models/news";
import {NewsFilterModel} from "../models/newsFilterModel";
import {PaginationResponseModel} from "../../models/paginationResponseModel";

export const getNews = createAction('[News] Get news', props<{filter: NewsFilterModel}>());

export const getNewsSuccess = createAction('[News] Get News Success', props<{ news: PaginationResponseModel<News[]> }>());

export const getPreviewNews = createAction('[News] Get News preview', props<{ filter: NewsFilterModel}>())

export const getPreviewNewsSuccess = createAction('[News] Get News preview Success', props<{ news: News[] }>());

