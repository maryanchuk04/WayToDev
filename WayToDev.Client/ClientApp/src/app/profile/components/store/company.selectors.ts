import {createSelector} from "@ngrx/store";
import {AppState} from "../../../store/appState";

export const selectFeature = (state: AppState) => state.company

export const companySelector = createSelector(
  selectFeature,
  state => state.company
)
