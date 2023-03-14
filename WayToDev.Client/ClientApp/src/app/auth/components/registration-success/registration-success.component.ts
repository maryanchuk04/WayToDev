import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../services/auth.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {TokenService} from "../../../services/token.service";

@Component({
  selector: 'app-registration-success',
  templateUrl: './registration-success.component.html',
  styleUrls: ['./registration-success.component.css']
})
export class RegistrationSuccessComponent implements OnInit {
  accountId: string;
  verifyForm: FormGroup;
  constructor(private actRoute: ActivatedRoute,
              private authService: AuthService,
              private formBuilder: FormBuilder,
              private route: Router,
              private tokenService: TokenService
  ) {
    this.verifyForm = this.formBuilder.group({
      inp1 : ["", Validators.required],
      inp2 : ["", Validators.required],
      inp3 : ["", Validators.required],
      inp4 : ["", Validators.required]
    })
  }

  ngOnInit(): void {
    this.actRoute.params.subscribe(params => {
      this.accountId = params.id;
    })
  }

  submit(){
    let verifyCode = (Object.values(this.verifyForm.value).join(""));
    this.authService.confirmEmail(this.accountId, verifyCode).subscribe(_=>{
      if(_.ok){
        this.tokenService.setAuthData({ role : _.body.role, token : _.body.token})
        this.route.navigate(["/profile"]);
      }
      else{
        this.verifyForm.reset();
        alert("Please input code again");
      }
    });
  }


}
