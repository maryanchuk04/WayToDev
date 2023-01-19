import { Injectable } from '@angular/core';
import {CanActivate, Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class RoleProfileGuardService implements CanActivate{

  constructor(private router: Router) { }

  canActivate(): boolean {
    if(Number(localStorage.getItem("role"))==0){
      return true;
    }
    this.router.navigate(["/sign-up"])
    return false;
  }
}
