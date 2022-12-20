import { Component, OnInit } from '@angular/core';
import { CompaniesAdministratingComponent } from '../companies-administrating/companies-administrating.component';
import { FeedbackAdministratingComponent } from '../feedback-administrating/feedback-administrating.component';
import { UsersAdministratingComponent } from '../users-administrating/users-administrating.component';
import { AdminMenu } from '../../models/adminMenu';


@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {
  showBurger = false;
  menuList: AdminMenu[] = [
    { name : "Users", index : 0 },
    { name : "Companies", index : 1 },
    { name : "Feedbacks", index : 2 }
  ];

  components = [UsersAdministratingComponent,
      CompaniesAdministratingComponent,
      FeedbackAdministratingComponent]

  currentComponent: any;

  constructor() { }

  ngOnInit(): void {
  }

  changeMenu(item: AdminMenu){
    this.currentComponent = this.components[item.index];
  }
}



