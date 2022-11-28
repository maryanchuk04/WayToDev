import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PreviewComponent } from './landing-page/components/main-page/preview/preview.component';
import { HeaderComponent } from './header/header.component';
import { MainPageComponent } from './landing-page/components/main-page/main-page/main-page.component';
import { WhatWeCanDoComponent } from './landing-page/components/main-page/what-we-can-do/what-we-can-do.component';
import { MainButtonComponent } from './ui/main-button/main-button.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from 'src/environments/environment';
import { NewsModule } from './news/news.module';
import { AuthModule } from './auth/auth.module';
import { MainNewsComponent } from './landing-page/components/main-news/main-news.component';
import { NewsShortInfoComponent } from './landing-page/components/main-news/components/news-short-info/news-short-info.component';
import { SpinnerComponent } from './ui/spinner/spinner/spinner.component';
import { SpinnerWrapperComponent } from './ui/spinner/spinner-wrapper/spinner-wrapper.component';
import { SpinnerModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';

@NgModule({
  declarations: [
    AppComponent,
    PreviewComponent,
    HeaderComponent,
    MainPageComponent,
    WhatWeCanDoComponent,
    MainButtonComponent,
    MainNewsComponent,
    NewsShortInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot(),
    SpinnerModule,
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
      autoPause: true,
    }),
    NewsModule,
    AuthModule,
    IconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
