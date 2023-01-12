import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProfileComponent} from './components/profile/profile.component';
import {MatSelectModule} from "@angular/material/select";
import {profileReducers} from "./store/profile.reducers";
import {EffectsModule} from "@ngrx/effects";
import {ProfileEffects} from "./store/profile.effects";
import {ReactiveFormsModule} from "@angular/forms";
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './components/profile/profile.component';
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";
import {CompanyEffects} from "./components/store/company.effects";

@NgModule({
  declarations: [
    ProfileComponent,
    EditInfoComponent
    ProfileComponent,
    ProfileCompanyComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    UiModule,
    MatButtonModule,
    MatSelectModule,
    StoreModule.forFeature('profile', profileReducers),
    EffectsModule.forFeature([ProfileEffects, CompanyEffects]),
    ReactiveFormsModule,
    CommonModule,
    UiModule,
    MatButtonModule
  ]
})
export class ProfileModule { }
