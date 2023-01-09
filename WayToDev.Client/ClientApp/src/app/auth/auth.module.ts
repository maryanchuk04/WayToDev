import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AuthRoutingModule } from './auth-routing.module';
import { SignInFormComponent } from './components/sign-in-form/sign-in-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './components/sign-up/sign-up.component';

import { UiModule } from '../ui/ui.module';
import { SignUpFormComponent } from './components/sign-up-form/sign-up-form.component';
import { SignUpCompanyComponent } from './components/sign-up-company/sign-up-company.component';
import { SignUpCompanyFormComponent } from './components/sign-up-company-form/sign-up-company-form.component';

@NgModule({
  declarations: [
    SignInComponent,
    SignInFormComponent,
    SignUpComponent,
    SignUpFormComponent,
    SignUpCompanyComponent,
    SignUpCompanyFormComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    UiModule,
    HttpClientModule,
  ]
})
export class AuthModule { }
