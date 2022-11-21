import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PreviewComponent } from './components/main-page/preview/preview.component';
import { HeaderComponent } from './components/header/header.component';
import { MainPageComponent } from './components/main-page/main-page/main-page.component';
import { WhatWeCanDoComponent } from './components/main-page/what-we-can-do/what-we-can-do.component';
import { MainButtonComponent } from './components/ui/main-button/main-button.component';


@NgModule({
  declarations: [
    AppComponent,
    PreviewComponent,
    HeaderComponent,
    MainPageComponent,
    WhatWeCanDoComponent,
    MainButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
