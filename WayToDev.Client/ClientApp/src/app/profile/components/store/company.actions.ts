import {createAction, props} from "@ngrx/store";
import {Company} from "../../../models/company";


export const getCurrentCompany = createAction('[Company] Get current company');

export const getCurrentCompanySuccess = createAction('[Company] Get company success', props<{ company: Company}>());
