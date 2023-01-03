import {createReducer, on} from "@ngrx/store";
import * as ProfileActions from './profile.actions'
import {ProfileInterface} from "./ProfileStore";

export const initialState: ProfileInterface = {
  user: null
}

export const profileReducers = createReducer(
  initialState,
  on(ProfileActions.getCurrentUser, (state) => (state)),
  on(ProfileActions.getCurrentUserSuccess, (state, action) => ({...state, user: action.user})),
  on(ProfileActions.getCurrentUserFailure, (state) => ({...state})),
  on(ProfileActions.updateCurrentUser, (state, action) => ({...state, user: action.user})),
  on(ProfileActions.updateTagsForUser,
    (state, action) => ({ ...state, user: state.user ? {...state.user, tags: action.tags} : null })),
);

