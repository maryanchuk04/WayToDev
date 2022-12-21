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
import { CompanyListItemComponent } from './components/companies-administrating/company-list-item/company-list-item.component';
import { NewsAdministratingComponent } from './components/news-administrating/news-administrating.component';
import { NewsListItemComponent } from './components/news-administrating/news-list-item/news-list-item.component';
import { CreateNewsComponent } from './components/news-administrating/create-news/create-news.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { FormModule } from '@coreui/angular';

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
    CompanyListItemComponent,
    NewsAdministratingComponent,
    NewsListItemComponent,
    CreateNewsComponent,

  ],
  imports: [
    MatSidenavModule,
    MatButtonModule,
    AdminRoutingModule,
    CommonModule,
    UiModule,
    MatDialogModule,
    FormModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatProgressBarModule
  ]
})
export class AdminModule { }
