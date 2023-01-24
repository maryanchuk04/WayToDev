import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailConfirmPageComponent } from './components/email-confirm-page/email-confirm-page.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import {RegistrationSuccessComponent} from "./components/registration-success/registration-success.component";

const authRoutes: Routes = [
  { path: "sign-in", component: SignInComponent },
  { path : "sign-up", component: SignUpComponent},
  { path : "email-confirmation/:token", component : EmailConfirmPageComponent},
  { path: "registration-success/:id", component : RegistrationSuccessComponent }
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
