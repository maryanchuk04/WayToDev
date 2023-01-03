import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuardService } from '../auth/services/auth-guard.service';

const profileRoutes: Routes = [
  { path: "profile", component: ProfileComponent, canActivate : [AuthGuardService] },
];

@NgModule({
  imports: [RouterModule.forChild(profileRoutes)],
  exports: [RouterModule]
})

export class ProfileRoutingModule { }

