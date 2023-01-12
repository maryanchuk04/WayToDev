import {createReducer, on} from "@ngrx/store";
import * as CompanyActions from './company.actions'
import {CompanyStore} from "./companyStore";

export const initialState: CompanyStore = {
  company: null
}

export const companyReducers = createReducer(
  initialState,
  on(CompanyActions.getCurrentCompany, state=>state),
  on(CompanyActions.getCurrentCompanySuccess, (state, action)=> ({...state, company: action.company}))
);
