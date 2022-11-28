import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './landing-page/components/main-page/main-page/main-page.component';

const routes: Routes = [
  { path: "", component: MainPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled', scrollOffset: [0, 0] })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
