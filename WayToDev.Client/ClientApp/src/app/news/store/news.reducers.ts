import {NewsStore} from "./newsStore";
import {createReducer, on} from "@ngrx/store";
import * as NewsActions from './news.actions'
export const initialState: NewsStore = {
  news: null,
  previewNews: []
}

export const newsReducers = createReducer(
  initialState,
  on((NewsActions.getNews), (state) => state),
  on(NewsActions.getNewsSuccess, (state, action)=>({...state, news: action.news})),
  on(NewsActions.getPreviewNews, state=> state),
  on(NewsActions.getPreviewNewsSuccess, (state, action)=> ({...state, previewNews: action.news}))
)
