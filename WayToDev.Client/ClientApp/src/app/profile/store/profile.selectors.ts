import {createSelector} from "@ngrx/store";
import {AppState} from "../../store/app-state";

export const selectFeature = (state: AppState) => state.profile;



export const userSelector = createSelector(
  selectFeature,
  (state) => state.user
);

export const companySelector = createSelector(
  selectFeature,
  state => state.company
)

