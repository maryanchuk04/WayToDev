import { Component, OnInit } from '@angular/core';
import {Store} from "@ngrx/store";
import {AppState} from "../../../../store/app-state";
import {handleChangePopup} from "../../../../ui/sidebar-popup/store/popup.actions";

@Component({
  selector: 'app-what-we-can-do',
  templateUrl: './what-we-can-do.component.html',
  styleUrls: ['./what-we-can-do.component.css']
})
export class WhatWeCanDoComponent implements OnInit {

  constructor(private store: Store<AppState>) { }

  ngOnInit(): void {
  }
}
