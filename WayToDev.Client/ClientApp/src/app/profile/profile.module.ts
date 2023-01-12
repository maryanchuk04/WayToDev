import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProfileComponent} from './components/profile/profile.component';
import {MatSelectModule} from "@angular/material/select";
import {profileReducers} from "./store/profile.reducers";
import {EffectsModule} from "@ngrx/effects";
import {ProfileEffects} from "./store/profile.effects";
import {ReactiveFormsModule} from "@angular/forms";
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";
import {EditInfoComponent} from "./components/edit-info/edit-info.component";
import {ProfileRoutingModule} from "./profile.routing.module";
import {MatButtonModule} from "@angular/material/button";
import {StoreModule} from "@ngrx/store";
import {UiModule} from "../ui/ui.module";

@NgModule({
  declarations: [
    ProfileComponent,
    EditInfoComponent,
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
    EffectsModule.forFeature([ProfileEffects]),
    ReactiveFormsModule,
    CommonModule,
    MatButtonModule
  ]
})
export class ProfileModule { }
