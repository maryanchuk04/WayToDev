import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Chat } from '../../models/chat';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css']
})
export class ChatContainerComponent implements OnInit {
  @Input() chat: Chat;
  messageForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.messageForm = this.formBuilder.group({
      message: ["", Validators.required]
    })
   }

  ngOnInit(): void {

    console.log(this.chat)
  }

  sendMessage(){
    console.log(this.messageForm);
  }

}
