import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerWrapperComponent } from './spinner/spinner-wrapper/spinner-wrapper.component';
import { SpinnerComponent } from './spinner/spinner/spinner.component';
import { SpinnerModule } from '@coreui/angular';



@NgModule({
  declarations: [
    SpinnerWrapperComponent,
    SpinnerComponent,
  ],
  imports: [
    CommonModule,
    SpinnerModule
  ],
  exports :[
    SpinnerWrapperComponent
  ]
})
export class UiModule { }
