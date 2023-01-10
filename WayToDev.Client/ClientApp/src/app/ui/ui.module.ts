import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerWrapperComponent } from './spinner/spinner-wrapper/spinner-wrapper.component';
import { SpinnerComponent } from './spinner/spinner/spinner.component';
import { SpinnerModule } from '@coreui/angular';
import { AlertComponent } from './alert/alert/alert.component';
import { AlertWrapperComponent } from './alert/alert-wrapper/alert-wrapper.component';
import { MatSnackBarModule } from '@angular/material/snack-bar'
import { AlertService } from './alert/alert.service';
import { SearchComponent } from './search/search.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { SvgIconComponent } from './svg-icon/svg-icon.component';
import { DynamicWavesComponent } from './dynamic-waves/dynamic-waves.component';

@NgModule({
  declarations: [
    SpinnerWrapperComponent,
    SpinnerComponent,
    AlertComponent,
    AlertWrapperComponent,
    SearchComponent,
    SubmitButtonComponent,
    SvgIconComponent,
    DynamicWavesComponent
  ],
  imports: [
    CommonModule,
    SpinnerModule,
    MatSnackBarModule
  ],
    exports: [
        SpinnerWrapperComponent,
        SearchComponent,
        SubmitButtonComponent,
        SvgIconComponent,
        DynamicWavesComponent
    ],
  providers : [
    AlertService
  ]
})
export class UiModule { }
