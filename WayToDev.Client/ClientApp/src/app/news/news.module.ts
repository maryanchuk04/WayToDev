import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { NewsPageComponent } from './components/news-page/news-page.component';
import { NewsPreviewComponent } from './components/news-preview/news-preview.component';
import { AllNewsPageComponent } from './components/all-news-page/all-news-page.component';
import { NewsRoutingModule } from './news-routing.module';

@NgModule({
  declarations: [
    NewsPageComponent,
    NewsPreviewComponent,
    AllNewsPageComponent
  ],
  imports: [
    NewsRoutingModule,
    CommonModule
  ]
})
export class NewsModule { }
