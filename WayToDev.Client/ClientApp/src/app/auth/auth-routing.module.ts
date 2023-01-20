import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import {SignUpCompanyComponent} from "./components/sign-up-company/sign-up-company.component";
import {SignUpLayoutComponent} from "./components/sign-up-layout/sign-up-layout.component";

const authRoutes: Routes = [
  { path: "sign-in", component: SignInComponent },
  { path : "sign-up-user", component: SignUpComponent},
  { path : "sign-up", component: SignUpLayoutComponent},
  { path: "sign-up-company", component: SignUpCompanyComponent}
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
