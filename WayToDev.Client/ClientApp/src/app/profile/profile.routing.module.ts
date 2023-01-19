import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";
import {RoleProfileGuardService} from "../auth/services/role-profile-guard.service";
import {RoleCompanyGuardService} from "../auth/services/role-company-guard.service";
import {ProfileCompanyViewComponent} from "./components/profile-company-view/profile-company-view.component";


const profileRoutes: Routes = [
  { path: "profile", component: ProfileComponent, canActivate: [RoleProfileGuardService] },
  { path : "profile-company", component: ProfileCompanyComponent, canActivate : [RoleCompanyGuardService]},
  { path: "profile/company/:id", component: ProfileCompanyViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(profileRoutes)],
  exports: [RouterModule]
})

export class ProfileRoutingModule { }

