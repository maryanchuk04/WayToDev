import { Component, Input, OnInit } from '@angular/core';
import { UserListItem } from 'src/app/admin/models/userListItem';

@Component({
  selector: 'app-user-list-item',
  templateUrl: './user-list-item.component.html',
  styleUrls: ['./user-list-item.component.css']
})
export class UserListItemComponent implements OnInit {
  @Input() user: UserListItem;
  constructor() { }

  ngOnInit(): void {
    console.log(this.user)
  }

}
