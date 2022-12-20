import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminPageComponent } from './components/admin-page/admin-page.component';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatButtonModule } from '@angular/material/button';
import { UsersAdministratingComponent } from './components/users-administrating/users-administrating.component';
import { CompaniesAdministratingComponent } from './components/companies-administrating/companies-administrating.component';
import { FeedbackAdministratingComponent } from './components/feedback-administrating/feedback-administrating.component';
import { UserListItemComponent } from './components/users-administrating/user-list-item/user-list-item.component';
import { UiModule } from '../ui/ui.module';
import { UserAdminPageComponent } from './components/users-administrating/user-admin-page/user-admin-page.component';
import { FeedbackRequestComponent } from './components/feedback-administrating/feedback-request/feedback-request.component';
import { FeedbackReviewComponent } from './components/feedback-administrating/feedback-review/feedback-review.component';
@NgModule({
  declarations: [
    AdminPageComponent,
    UsersAdministratingComponent,
    CompaniesAdministratingComponent,
    FeedbackAdministratingComponent,
    UserListItemComponent,
    UserAdminPageComponent,
    FeedbackRequestComponent,
    FeedbackReviewComponent,

  ],
  imports: [
    MatSidenavModule,
    MatButtonModule,
    AdminRoutingModule,
    CommonModule,
    UiModule
  ]
})
export class AdminModule { }
