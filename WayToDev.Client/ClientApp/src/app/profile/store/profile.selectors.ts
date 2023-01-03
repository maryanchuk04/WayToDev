import {createSelector} from "@ngrx/store";
import {AppState} from "../../Store/AppState";
export const selectFeature = (state: AppState) => state.profile;
export const userSelector = createSelector(
  selectFeature,
  (state) => state.user
);
