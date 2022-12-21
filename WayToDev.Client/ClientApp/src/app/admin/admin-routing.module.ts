import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './components/admin-page/admin-page.component';
import { FeedbackReviewComponent } from './components/feedback-administrating/feedback-review/feedback-review.component';
import { UserAdminPageComponent } from './components/users-administrating/user-admin-page/user-admin-page.component';

const adminRoutes: Routes = [
    { path : "admin", component: AdminPageComponent},
    { path : "admin/users/:id", component: UserAdminPageComponent },
    { path : "admin/feedback/:id", component : FeedbackReviewComponent}
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
