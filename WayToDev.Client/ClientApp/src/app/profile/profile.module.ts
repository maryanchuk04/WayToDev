import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ProfileComponent} from './components/profile/profile.component';
import {ProfileRoutingModule} from "./profile.routing.module";
import {UiModule} from "../ui/ui.module";
import {MatButtonModule} from "@angular/material/button";
import {EditInfoComponent} from "./components/edit-info/edit-info.component";
import {MatSelectModule} from "@angular/material/select";
import {StoreModule} from "@ngrx/store";
import {profileReducers} from "./store/profile.reducers";
import {EffectsModule} from "@ngrx/effects";
import {ProfileEffects} from "./store/profile.effects";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    ProfileComponent,
    EditInfoComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    UiModule,
    MatButtonModule,
    MatSelectModule,
    StoreModule.forFeature('profile', profileReducers),
    EffectsModule.forFeature([ProfileEffects]),
    ReactiveFormsModule
  ]
})
export class ProfileModule {
}
