import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SpinnerWrapperComponent} from './spinner/spinner-wrapper/spinner-wrapper.component';
import {SpinnerComponent} from './spinner/spinner/spinner.component';
import {SpinnerModule} from '@coreui/angular';
import {AlertComponent} from './alert/alert/alert.component';
import {AlertWrapperComponent} from './alert/alert-wrapper/alert-wrapper.component';
import {MatSnackBarModule} from '@angular/material/snack-bar'
import {AlertService} from './alert/alert.service';
import {SearchComponent} from './search/search.component';
import {BasicFieldComponent} from "./basic-field/basic-field.component";
import { UploadImageComponent } from './upload-image/upload-image.component';
import { TechItemComponent } from './tech-item/tech-item.component';
import {MatChipsModule} from "@angular/material/chips";
import {MatIconModule} from "@angular/material/icon";
import {TechstackFieldComponent} from "./techstack-field/techstack-field.component";


@NgModule({
  declarations: [
    SpinnerWrapperComponent,
    SpinnerComponent,
    AlertComponent,
    AlertWrapperComponent,
    SearchComponent,
    BasicFieldComponent,
    UploadImageComponent,
    TechItemComponent,
    TechstackFieldComponent
  ],
  imports: [
    CommonModule,
    SpinnerModule,
    MatSnackBarModule,
    MatChipsModule,
    MatIconModule,

  ],
  exports: [
    SpinnerWrapperComponent,
    SearchComponent,
    BasicFieldComponent,
    UploadImageComponent,
    TechstackFieldComponent
  ],
  providers: [
    AlertService
  ]
})
export class UiModule {
}
