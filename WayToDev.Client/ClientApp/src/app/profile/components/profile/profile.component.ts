import { Component, OnInit } from '@angular/core';
import {User} from "../../models/user";
import {select, Store} from "@ngrx/store";

import * as ProfileActions from '../../store/profile.actions'
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  constructor() {
  }

  ngOnInit(): void {
  }
}
