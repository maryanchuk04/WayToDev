import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerWrapperComponent } from './spinner/spinner-wrapper/spinner-wrapper.component';
import { SpinnerComponent } from './spinner/spinner/spinner.component';
import { SpinnerModule } from '@coreui/angular';
import { AlertComponent } from './alert/alert/alert.component';
import { AlertWrapperComponent } from './alert/alert-wrapper/alert-wrapper.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AlertService } from './alert/alert.service';
import { SearchComponent } from './search/search.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { SvgIconComponent } from './svg-icon/svg-icon.component';
import { DynamicWavesComponent } from './dynamic-waves/dynamic-waves.component';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { TechstackFieldComponent } from './techstack-field/techstack-field.component';
import { UploadImageComponent } from './upload-image/upload-image.component';
import { TechItemComponent } from './tech-item/tech-item.component';
import { SidebarComponentComponent } from './sidebar-popup/sidebar-component/sidebar-component.component';
import { ProfileUserViewComponent } from '../profile/components/profile-user-view/profile-user-view.component';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    SpinnerWrapperComponent,
    SpinnerComponent,
    AlertComponent,
    AlertWrapperComponent,
    SearchComponent,
    SubmitButtonComponent,
    SvgIconComponent,
    DynamicWavesComponent,
    TechstackFieldComponent,
    UploadImageComponent,
    TechItemComponent,
    SidebarComponentComponent,
    ProfileUserViewComponent,
  ],
  imports: [
    CommonModule,
    SpinnerModule,
    MatSnackBarModule,
    MatChipsModule,
    MatIconModule,
    MatButtonModule,
  ],
  exports: [
    SpinnerWrapperComponent,
    SearchComponent,
    SubmitButtonComponent,
    SvgIconComponent,
    DynamicWavesComponent,
    TechstackFieldComponent,
    UploadImageComponent,
    SidebarComponentComponent
  ],
  providers: [AlertService],
})
export class UiModule {}
