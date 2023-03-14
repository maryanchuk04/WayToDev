import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {UserService} from "../../services/user.service";
import {Observable} from "rxjs";
import {User} from "../../models/user";
import {AppState} from "../../../store/app-state";
import {select, Store} from "@ngrx/store";
import {popupSelector} from "../../../ui/sidebar-popup/store/popup.selectors";
import {handleChangePopup} from "../../../ui/sidebar-popup/store/popup.actions";

@Component({
  selector: 'app-profile-user-view',
  templateUrl: './profile-user-view.component.html',
  styleUrls: ['./profile-user-view.component.css']
})
export class ProfileUserViewComponent implements OnInit {
  user$: Observable<User>;
  constructor(private store: Store<AppState>, private userService: UserService) {
      this.store.pipe(select(popupSelector)).subscribe(_=>{
        this.user$ = this.userService.getUserById(_.userId);
      });
  }

  ngOnInit(): void {
  }

  // function for open profile user with id
  // handleOpen(){
  //   this.store.dispatch(handleChangePopup({id : "1268B5DE-D320-467F-A7DC-08DAF8A4273E"}));
  // }
}
