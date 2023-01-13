import {Action, createAction, props} from "@ngrx/store";
import {User} from "../models/user";
import {Actions} from "@ngrx/effects";
import {TechItem} from "../../models/techItem";
import {Company} from "../../models/company";

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

export const updateCurrentCompany = createAction(
  '[Profile] Update current company',
  props<{ company: Company}>()
)

export const updateTagsForUser = createAction(
  '[Profile] Update user tags',
  props<{ tags : TechItem[] }>()
)


export const getCurrentCompany = createAction('[Company] Get current company');

export const getCurrentCompanySuccess = createAction('[Company] Get company success', props<{ company: Company}>());

export const updateTagsForCompany = createAction(
  '[Profile] Update user tags',
  props<{ tags : TechItem[] }>()
)
