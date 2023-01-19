import {AppState} from "../../../store/app-state";
import {createSelector} from "@ngrx/store";


export const selectFeature = (state: AppState) => state.popup;

export const popupSelector = createSelector(
  selectFeature,
  state => state
);

