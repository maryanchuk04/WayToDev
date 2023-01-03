import { Component, OnInit } from '@angular/core';
import {User} from "../../models/user";
import {Observable} from "rxjs";
import {select, Store} from "@ngrx/store";
import { userSelector } from "../../store/profile.selectors";
import {AppState} from "../../../Store/AppState";
import * as ProfileActions from '../../store/profile.actions'
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  constructor(private store: Store<AppState>) {

  }

  ngOnInit(): void {
  }

  saveInfo(user: User): void{
    this.store.dispatch(ProfileActions.updateCurrentUser({ user }))
  }
}
