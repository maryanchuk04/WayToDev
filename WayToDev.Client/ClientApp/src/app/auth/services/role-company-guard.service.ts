import { Injectable } from '@angular/core';
import {CanActivate, Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class RoleCompanyGuardService implements CanActivate{

  constructor(private router: Router) { }

  canActivate(): boolean {
    if(!!localStorage.getItem("role") == true){
      return true;
    }
    this.router.navigate(["/sign-in"])
    return false;
  }
}
