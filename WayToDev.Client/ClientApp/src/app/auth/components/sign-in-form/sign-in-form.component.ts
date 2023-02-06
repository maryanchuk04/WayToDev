import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { LoginModel } from '../../models/loginModel';
import { HttpResponse } from '@angular/common/http';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.css'],
})
export class SignInFormComponent implements OnInit {
  public signInForm!: FormGroup;
  public submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.signInForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.email, Validators.required])],
      password: ['', Validators.required],
    });
  }

  get formControl() {
    return this.signInForm.controls;
  }

  onLogin() {
    this.submitted = true;
    if (this.signInForm.valid) {
      console.log(this.signInForm);
      this.authService.authenticate(new LoginModel(this.signInForm.value.email, this.signInForm.value.password))
        .subscribe((response: HttpResponse<any>)=>{
          if(response.ok){
            console.log(response)
            if(response.body.role == 0){
              this.tokenService.setUserAuthData({ token: response.body.token, id: response.body.id, role: response.body.role});
              this.router.navigate(["/profile"]);
              console.log(response.body)
            }

            if(response.body.role == 1)
              this.tokenService.setAuthData({ token: response.body.token, role: response.body.role});
              this.router.navigate(["/profile-company"])
          }
        });
    }
  }
}
