import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthModule } from './auth/auth.module';
import { MainPageComponent } from './landing-page/components/main-page/main-page/main-page.component';
import { ProfileModule } from './profile/profile.module';
import { AuthGuardService } from './auth/services/auth-guard.service';
const routes: Routes = [
  { path: '', component: MainPageComponent },
  { path: '', loadChildren: () => AuthModule },
  { path: '', loadChildren: () => ProfileModule, canActivate : [ AuthGuardService]}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled',
      scrollOffset: [0, 0],
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
