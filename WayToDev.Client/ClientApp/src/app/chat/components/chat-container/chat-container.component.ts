import { Component, OnInit, Input, ViewChild, AfterViewInit, ElementRef, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, tap } from 'rxjs';
import { Chat } from '../../models/chat';
import { Message } from '../../models/message';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css']
})
export class ChatContainerComponent implements OnInit, AfterViewInit {
  @ViewChild('scroll', { static: true }) scroll: any;
  @Input() chat$: Observable<Chat>;
  messageForm: FormGroup;
  messages: Message[];

  constructor(private formBuilder: FormBuilder) {
    this.messageForm = this.formBuilder.group({
      message: ["", Validators.required]
    })

  }

  ngAfterViewInit() {

  }

  ngOnInit(): void {
    this.chat$.subscribe(_ => {
      this.messages = _.messages;

    })
  }

  sendMessage() {
    this.messages.push({ text: "Hello", when: "12/20/2003", id: "asdsadsa", from: { id: "me" } });
    this.scrollDown();
  }

  private scrollDown() {
      this.scroll.nativeElement.scrollTop = this.scroll.nativeElement.scrollHeight;
  }

}
