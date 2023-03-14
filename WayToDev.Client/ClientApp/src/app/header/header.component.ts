import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import {Header} from "./models/header";
import {companyHeader, defaultHeader, userHeader} from "./header-variants";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})


export class HeaderComponent implements OnInit {
  headerStyle: boolean = false;
  header: Header;
  constructor(private router: Router) {
    this.roleHandler();
    this.router.events.subscribe((event) => {
      this.headerStyleHandler(event);
      this.roleHandler()
    })
  }

  ngOnInit(): void {
  }

  headerStyleHandler(event: any){
    //if this is main page headerStyle equals false!
    if (event instanceof NavigationEnd) {
      this.headerStyle = event.url !== '/';
      if(!this.headerStyle){
        const scrollTrigger = 60;
        window.onscroll = function () {
          if (window.scrollY >= scrollTrigger || window.pageYOffset >= scrollTrigger) {
            document.getElementsByTagName("header")[0].classList.add('beauty');
          } else {
            document.getElementsByTagName("header")[0].classList.remove('beauty');
          }

        };
      }
      else window.onscroll = null;
    }
  }

  roleHandler(){
    let role = localStorage.getItem("role");
    if(role == null){
      this.header = defaultHeader;
      return;
    }

    switch (Number(role)) {
      case 0: {
        this.header = userHeader;
        return;
      }
      case 1: {
        this.header = companyHeader;
        return;
      }
    }
  }
}




