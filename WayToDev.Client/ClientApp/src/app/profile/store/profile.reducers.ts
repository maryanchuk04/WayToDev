import {createReducer, on} from "@ngrx/store";
import * as ProfileActions from './profile.actions'
import {ProfileInterface} from "./ProfileStore";
import {act} from "@ngrx/effects";

export const initialState: ProfileInterface = {
  company: null,
  user: null
}

export const profileReducers = createReducer(
  initialState,
  on(ProfileActions.getCurrentCompany, state=>state),
  on(ProfileActions.getCurrentCompanySuccess, (state, action)=> ({...state, company: action.company})),
  on(ProfileActions.getCurrentUser, (state) => (state)),
  on(ProfileActions.getCurrentUserSuccess, (state, action) => ({...state, user: action.user})),
  on(ProfileActions.getCurrentUserFailure, (state) => ({...state})),
  on(ProfileActions.updateCurrentUser, (state, action) => ({...state, user: action.user})),
  on(ProfileActions.updateTagsForCompany, (state, action)=> ({ ...state, company: state.company ? {...state.company, tags: action.tags} : null })),
  on(ProfileActions.updateTagsForUser,
    (state, action) => ({ ...state, user: state.user ? {...state.user, tags: action.tags} : null })),
);

