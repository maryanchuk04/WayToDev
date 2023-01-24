import { Component, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import {AuthService} from "../auth/services/auth.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})


export class HeaderComponent implements OnInit {
  //if this is main page headerStyle equals false!
  headerStyle: boolean = false;
  headerLinks: HeaderLink[];

  constructor(private router: Router, private authService: AuthService) {
    this.authService.isAuthenticatedObs().subscribe((isAuthenticated: boolean) => {
      console.log(isAuthenticated);
    });
    this.headerLinks = [
      { route: "/", name: "Home" },
      { route: "news", name: "News" },
      { route: "sign-in", name: "SignIn" },
      { route: "sign-up", name: "SignUp" },
    ];
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.headerStyle = event.url !== '/';
        console.log(this.headerStyle)
        if(!this.headerStyle){
          var scrollTrigger = 60;
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
    })
  }

  ngOnInit(): void {

  }

}

interface HeaderLink {
  route: string
  name: string
}
