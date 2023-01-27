import { Component, OnInit } from '@angular/core';
import {select, Store} from "@ngrx/store";
import {AppState} from "./store/app-state";
import {popupSelector} from "./ui/sidebar-popup/store/popup.selectors";
import {userSelector} from "./profile/store/profile.selectors";
import {Observable} from "rxjs";
import {PopupStore} from "./ui/sidebar-popup/store/popupStore";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  popup:PopupStore;
  popup$: Observable<PopupStore>
  title = 'WayToDev-client';
  constructor(private store: Store<AppState>) {
    this.popup$ = this.store.pipe(select(popupSelector));
    this.popup$.subscribe(_=>{
      this.popup = _;
      console.log(this.popup)
    })
  }
  ngOnInit(): void {
  }
}
