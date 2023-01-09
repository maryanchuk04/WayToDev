import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-up-company-form',
  templateUrl: './sign-up-company-form.component.html',
  styleUrls: ['./sign-up-company-form.component.css']
})
export class SignUpCompanyFormComponent implements OnInit {
  companyForm: FormGroup;
  submitted: boolean = false;
  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router) {
    this.companyForm = formBuilder.group({
      email : ["", Validators.compose([Validators.email, Validators.required])],
      password : ["", Validators.compose([
        Validators.required, Validators.pattern(
          "(?=.*[A-Za-z])(?=.*[0-9])(?=.*[$@$!#^~%*?&,.<>\"'\\;:{\\}\\[\\]\\|\\+\\-\\=\\_\\)\\(\\)\\`\\/\\\\\\]])[A-Za-z0-9d$@].{7,}"
        )])],
      confirmPassword : ["",Validators.required],
      companyName: ["", Validators.required]
    })

  }

  ngOnInit(): void {
  }

  onSubmit(){
    this.submitted = true;
    if(this.companyForm.valid) {
      this.authService.registration({
        ...this.companyForm.value,
        role: 1
      }).subscribe(_=>{
        if(_.status == 200){
          this.router.navigate(["/"])
        }
      })
    }
  }

  get formControl(){
    return this.companyForm.controls;
  }


}

