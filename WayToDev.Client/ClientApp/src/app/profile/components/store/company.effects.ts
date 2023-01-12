import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import * as CompanyActions from './company.actions'
import {catchError, map, mergeMap} from "rxjs";
import {CompanyService} from "../../services/company.service";
@Injectable()
export class CompanyEffects{
  getCurrentCompany$ = createEffect(()=>
    this.actions$.pipe(
      ofType(CompanyActions.getCurrentCompany),
      mergeMap(()=>{
        return this.companyService.getCurrentCompany().pipe(
          map((company) => CompanyActions.getCurrentCompanySuccess({ company }))
        )
      })
    )
  )

  constructor(private actions$: Actions, private companyService: CompanyService) {}
}
