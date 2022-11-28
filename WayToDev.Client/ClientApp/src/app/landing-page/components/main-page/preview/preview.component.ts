import { Component, OnInit } from '@angular/core';

declare var particlesJS: any;

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.css']
})
export class PreviewComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    particlesJS.load("particles-js","../../../assets/particle-config.json",null);
  }

}
