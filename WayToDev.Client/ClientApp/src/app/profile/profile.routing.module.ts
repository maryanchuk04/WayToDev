import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";
import {RoleProfileGuardService} from "../auth/services/role-profile-guard.service";
import {RoleCompanyGuardService} from "../auth/services/role-company-guard.service";


const profileRoutes: Routes = [
  { path: "profile", component: ProfileComponent, canActivate: [RoleProfileGuardService] },
  { path : "profile-company", component: ProfileCompanyComponent, canActivate : [RoleCompanyGuardService]}
];

@NgModule({
  imports: [RouterModule.forChild(profileRoutes)],
  exports: [RouterModule]
})

export class ProfileRoutingModule { }

