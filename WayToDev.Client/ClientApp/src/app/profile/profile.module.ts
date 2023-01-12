import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './components/profile/profile.component';
import {ProfileCompanyComponent} from "./components/profile-company/profile-company.component";
import {ProfileRoutingModule} from "./profile.routing.module";
import {StoreModule} from "@ngrx/store";
import {companyReducers} from "./components/store/company.reducers";
import {EffectsModule} from "@ngrx/effects";
import {CompanyEffects} from "./components/store/company.effects";
import {UiModule} from "../ui/ui.module";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [
    ProfileComponent,
    ProfileCompanyComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    StoreModule.forFeature('company', companyReducers),
    EffectsModule.forFeature([CompanyEffects]),
    UiModule,
    MatButtonModule
  ]
})
export class ProfileModule { }
