import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AuthRoutingModule } from './auth-routing.module';
import { SignInFormComponent } from './components/sign-in-form/sign-in-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './components/sign-up/sign-up.component';

import { UiModule } from '../ui/ui.module';

@NgModule({
  declarations: [
    SignInComponent,
    SignInFormComponent,
    SignUpComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    UiModule
  ]
})
export class AuthModule { }
