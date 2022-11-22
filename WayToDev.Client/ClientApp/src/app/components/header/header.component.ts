import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  headerLinks : HeaderLink[];
  constructor() {
    this.headerLinks = [
      { route : "/", name : "Home"},
      { route : "news", name : "News"},
      { route : "", name : "SignIn"},
      { route : "", name : "SignUp"},
    ]
  }

  ngOnInit(): void {
    var scrollTrigger = 60;
    window.onscroll = function(){
      if (window.scrollY >= scrollTrigger || window.pageYOffset >= scrollTrigger) {
      document.getElementsByTagName("header")[0].classList.add('beauty');
      } else {
        document.getElementsByTagName("header")[0].classList.remove('beauty');
      }
    };
  }
}

interface HeaderLink{
  route : string
  name : string
}
