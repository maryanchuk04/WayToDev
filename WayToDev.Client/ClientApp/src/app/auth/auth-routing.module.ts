import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import {SignUpCompanyComponent} from "./components/sign-up-company/sign-up-company.component";

const authRoutes: Routes = [
  { path: "sign-in", component: SignInComponent },
  { path : "sign-up", component: SignUpComponent},
  { path: "sign-up-company", component: SignUpCompanyComponent}
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
