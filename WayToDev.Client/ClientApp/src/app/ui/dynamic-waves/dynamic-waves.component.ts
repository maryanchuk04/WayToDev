import {Component, OnDestroy, OnInit} from '@angular/core';

@Component({
  selector: 'app-dynamic-waves',
  templateUrl: './dynamic-waves.component.html',
  styleUrls: ['./dynamic-waves.component.css']
})
export class DynamicWavesComponent implements OnInit, OnDestroy {
  show:boolean;
  constructor() { }

  ngOnInit(): void {
    this.show = true;
  }

  ngOnDestroy(): void {
    this.show = false;
  }

}
