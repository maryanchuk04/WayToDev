import { Injectable } from '@angular/core';
import {CanActivate, Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class RoleProfileGuardService implements CanActivate{

  constructor(private router: Router) { }

  canActivate(): boolean {
    if( !!localStorage.getItem("role") == false){
      return true;
    }
    this.router.navigate(["/sign-in"])
    return false;
  }
}
