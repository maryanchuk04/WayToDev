import {Action, createAction, props} from "@ngrx/store";
import {User} from "../models/user";
import {Actions} from "@ngrx/effects";
import {TechItem} from "../../models/techItem";

export const getCurrentUser = createAction('[Profile] Get Current user');

export const getCurrentUserSuccess = createAction(
  '[Profile] Get Current user success',
  props<{ user : User} >()
  );

export const getCurrentUserFailure = createAction(
  '[Profile] Get Current user failure',
  props<{ error: string }>()
);

export const updateCurrentUser = createAction(
  '[Profile] Update current user',
  props<{ user: User }>()
)


export const updateTagsForUser = createAction(
  '[Profile] Update user tags',
  props<{ tags : TechItem[] }>()
)
