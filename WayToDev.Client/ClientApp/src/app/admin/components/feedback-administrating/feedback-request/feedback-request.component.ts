import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FeedbackRequest } from 'src/app/admin/models/feedbackRequest';

@Component({
  selector: 'app-feedback-request',
  templateUrl: './feedback-request.component.html',
  styleUrls: ['./feedback-request.component.css']
})
export class FeedbackRequestComponent implements OnInit {
  @Input() feedback: FeedbackRequest;
  constructor( private router: Router) { }

  ngOnInit(): void {
  }

  review(){
    console.log("hello")
    this.router.navigate(["admin/feedback/", this.feedback.id])
  }

}
