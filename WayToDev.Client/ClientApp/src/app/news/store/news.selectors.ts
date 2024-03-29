import {createSelector} from "@ngrx/store";
import {AppState} from "../../store/appState";

const selectorFeature = (state: AppState) => state.news
export const newsSelector = createSelector(
  selectorFeature,
  state => state.news
)

export const newsPreviewSelector = createSelector(
  selectorFeature,
  state => state.previewNews
)
