import {Injectable} from "@angular/core";
import {UserService} from "../services/user.service";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import * as ProfileActions from './profile.actions'
import {catchError, EMPTY, exhaustAll, exhaustMap, map, mergeMap, of} from "rxjs";
import {CompanyService} from "../services/company.service";

@Injectable()
export class ProfileEffects{
  getCurrentUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.getCurrentUser),
      mergeMap(() => {
        return this.userService.getCurrentUser().pipe(
          map((user) => ProfileActions.getCurrentUserSuccess({ user })),
          catchError((error) =>
            of(ProfileActions.getCurrentUserFailure({ error: error.message }))
          )
        );
      })
    )
  );

  updateCurrentUser$ = createEffect(()=>
    this.actions$.pipe(
      ofType(ProfileActions.updateCurrentUser),
      map(action => action.user),
      exhaustMap((user)=> this.userService.updateUserInfo(user).pipe(
        map(()=>{return ProfileActions.getCurrentUserSuccess({user})} ,
        catchError((error)=>
          of(ProfileActions.getCurrentUserFailure({error : error.message}))
        )
      ))
    )
  ));
  getCurrentCompany$ = createEffect(()=>
    this.actions$.pipe(
      ofType(ProfileActions.getCurrentCompany),
      mergeMap(()=>{
        return this.companyService.getCurrentCompany().pipe(
          map((company) => ProfileActions.getCurrentCompanySuccess({ company }))
        )
      })
    )
  )

  constructor(private actions$: Actions,
              private userService: UserService,
              private companyService: CompanyService) {
  }
}
