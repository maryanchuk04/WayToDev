import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router"
@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css']
})
export class SignUpFormComponent implements OnInit {
  public signUpForm!: FormGroup;
  public submitted = false;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router) {
    this.signUpForm = new FormBuilder().group({
      email : ["", Validators.compose([Validators.email, Validators.required])],
      password : ["", Validators.compose([
        Validators.required, Validators.pattern(
          "(?=.*[A-Za-z])(?=.*[0-9])(?=.*[$@$!#^~%*?&,.<>\"'\\;:{\\}\\[\\]\\|\\+\\-\\=\\_\\)\\(\\)\\`\\/\\\\\\]])[A-Za-z0-9d$@].{7,}"
      )])],
      confirmPassword : ["",Validators.required],
      userName : ["",Validators.required]
    })

    this.signUpForm.addValidators(
      this.createCompareValidator(this.signUpForm.get("password")!,
      this.signUpForm.get("confirmPassword")!
    ));
   }

  ngOnInit(): void {
  }

  handleSubmit(){
    this.submitted = true;
    if(this.signUpForm.valid){
      this.authService.registration(this.formValues).subscribe(response =>{
        if(response.status === 200){
          this.router.navigate(["/registration-success", response.body.accountId])
        }
      });
    }
  }

  get formControl(){
    return this.signUpForm.controls;
  }

  get formValues(){
    return this.signUpForm.value;
  }

  createCompareValidator(controlOne: AbstractControl, controlTwo: AbstractControl) {
    return () => {
    if (controlOne.value !== controlTwo.value)
      return { match_error: 'Value does not match' };
    return null;
  };

}
}
