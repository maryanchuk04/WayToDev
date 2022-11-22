import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './components/main-page/main-page/main-page.component';
import { AllNewsPageComponent } from './components/news/all-news-page/all-news-page.component';
import { NewsPageComponent } from './components/news/news-page/news-page.component';

const routes: Routes = [
  { path: "", component: MainPageComponent },
  { path: "news/:id", component: NewsPageComponent },
  { path: "news", component: AllNewsPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
