import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { LoginModel } from '../../models/loginModel';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.css']
})
export class SignInFormComponent implements OnInit {
  public signInForm!: FormGroup;
  public submitted = false;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.signInForm = this.formBuilder.group({
      email : ["", Validators.compose([Validators.email, Validators.required])],
      password : ["", Validators.required]
    })
  }

  get formControl(){
    return this.signInForm.controls;
  }

  onLogin() {

    this.submitted = true;
    if(this.signInForm.valid){
      console.log(this.signInForm);
      this.authService.authenticate(new LoginModel(this.signInForm.value.email, this.signInForm.value.password))
        .subscribe((response: HttpResponse<any>)=>{
          console.log(response)
          if(response.ok){
            localStorage.setItem("token", (response.body.token));
            localStorage.setItem("role", (response.body.role));
            if(response.body.role == 0)
              this.router.navigate(["/profile"]);
            else this.router.navigate(["/profile-company"])
          }
        });

    }

  }
}
