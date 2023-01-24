import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrls: ['./create-news.component.css']
})
export class CreateNewsComponent implements OnInit {
  public createForm!: FormGroup;
  public loading: boolean = false;
  selectedFile: any = null;

  onFileSelected(event: any): void {
      this.selectedFile = event.target.files[0] ?? null;
  }

  constructor(private formBuilder: FormBuilder) {
    this.createForm = this.formBuilder.group({
      title: ["", Validators.required],
      shortDescription: ["", Validators.compose([Validators.required, Validators.maxLength(200)]) ],
      text: ["", Validators.required]
    })
  }

  ngOnInit(): void {
  }

  onSubmit(){
    const requestObject = {...this.createForm.value, file : this.selectedFile };
    console.log(requestObject)
  }

  get controls(){
    return this.createForm.controls;
  }

}
