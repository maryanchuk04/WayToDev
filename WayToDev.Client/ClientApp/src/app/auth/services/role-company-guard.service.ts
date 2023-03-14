import { Injectable } from '@angular/core';
import {CanActivate, Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class RoleCompanyGuardService implements CanActivate{

  constructor(private router: Router) { }

  canActivate(): boolean {
    if(Number(localStorage.getItem("role")) == 1){
      return true;
    }
    this.router.navigate(["/sign-up"])
    return false;
  }
}
