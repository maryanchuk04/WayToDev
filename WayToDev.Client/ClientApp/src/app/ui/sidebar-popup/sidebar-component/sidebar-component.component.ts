import {Component, Input, OnInit} from '@angular/core';
import {animate, state, style, transition, trigger} from "@angular/animations";
import {AppState} from "../../../store/app-state";
import {Store} from "@ngrx/store";
import {handleChangePopup} from "../store/popup.actions";

const enterTransition = transition(':enter', [
  style({
    transform: 'translate3d(0,0,0)'
  }),
  animate('300ms ease-in-out')
]);
const exitTransition = transition(':leave', [
  style({
    transform: 'translate3d(100%, 0, 0)'
  }),
  animate('300ms ease-in-out')
]);
const fadeIn = trigger('fadeIn', [enterTransition]);
const fadeOut = trigger('fadeOut', [exitTransition]);

@Component({
  selector: 'app-sidebar-component',
  templateUrl: './sidebar-component.component.html',
  styleUrls: ['./sidebar-component.component.css'],
  animations: [fadeIn, fadeOut]
})
export class SidebarComponentComponent implements OnInit {
  @Input() open: boolean;
  constructor(private store: Store<AppState>) {
  }

  ngOnInit(): void {
  }

  handleClose(){
    this.store.dispatch(handleChangePopup({id: ""}))
  }
}
