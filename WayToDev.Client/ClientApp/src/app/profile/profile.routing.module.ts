import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";

const profileRoutes: Routes = [
  { path: "profile", component: ProfileComponent },
  { path : "profile-company", component: ProfileCompanyComponent}
];

@NgModule({
  imports: [RouterModule.forChild(profileRoutes)],
  exports: [RouterModule]
})

export class ProfileRoutingModule { }

