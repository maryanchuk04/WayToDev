import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllNewsPageComponent } from './components/all-news-page/all-news-page.component';
import { NewsPageComponent } from './components/news-page/news-page.component';

const newsRoutes: Routes = [
  { path: "news/:id", component: NewsPageComponent },
  { path: "news", component: AllNewsPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(newsRoutes)],
  exports: [RouterModule]
})
export class NewsRoutingModule { }
