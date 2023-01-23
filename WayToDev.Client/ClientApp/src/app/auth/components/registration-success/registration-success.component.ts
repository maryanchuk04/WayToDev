import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-registration-success',
  templateUrl: './registration-success.component.html',
  styleUrls: ['./registration-success.component.css']
})
export class RegistrationSuccessComponent implements OnInit {
  accountId: string;
  constructor(private actRoute: ActivatedRoute, private authService: AuthService) { }

  ngOnInit(): void {
    this.actRoute.params.subscribe(params => {
      this.accountId = params.id;
    })
  }



}
