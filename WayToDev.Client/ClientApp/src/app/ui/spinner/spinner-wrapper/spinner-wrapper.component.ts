import { Component, Input, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-spinner-wrapper',
  templateUrl: './spinner-wrapper.component.html',
  styleUrls: ['./spinner-wrapper.component.css']
})
export class SpinnerWrapperComponent implements OnInit {
  @Input() condition:boolean;

  constructor() { }

  ngOnInit(): void {

  }
}
