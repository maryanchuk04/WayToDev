import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PreviewComponent } from './landing-page/components/main-page/preview/preview.component';
import { HeaderComponent } from './header/header.component';
import { MainPageComponent } from './landing-page/components/main-page/main-page/main-page.component';
import { WhatWeCanDoComponent } from './landing-page/components/main-page/what-we-can-do/what-we-can-do.component';
import { MainButtonComponent } from './ui/main-button/main-button.component';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from 'src/environments/environment';
import { NewsModule } from './news/news.module';
import { AuthModule } from './auth/auth.module';
import { MainNewsComponent } from './landing-page/components/main-news/main-news.component';
import { NewsShortInfoComponent } from './landing-page/components/main-news/components/news-short-info/news-short-info.component';
import { IconModule } from '@coreui/icons-angular';
import { AdminModule } from './admin/admin.module';
import { JwtModule } from '@auth0/angular-jwt';
import { ChatModule } from './chat/chat.module';
import {profileReducers} from "./profile/store/profile.reducers";
import {popupReducers} from "./ui/sidebar-popup/store/popup.reducers";
import {UiModule} from "./ui/ui.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgParticlesModule } from "ng-particles";
import { HttpClientModule } from '@angular/common/http';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    PreviewComponent,
    HeaderComponent,
    MainPageComponent,
    WhatWeCanDoComponent,
    MainButtonComponent,
    MainNewsComponent,
    NewsShortInfoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StoreModule.forRoot({
      profile: profileReducers,
      popup: popupReducers
    }),
    EffectsModule.forRoot(),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
      autoPause: true,
    }),
    NewsModule,
    AuthModule,
    IconModule,
    AdminModule,
    IconModule,
    UiModule,
    ChatModule,
    NgParticlesModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:44443', 'localhost:7218'],
      },
    }),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
