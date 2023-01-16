import { Component, OnInit, Input, ViewChild, AfterViewInit, ElementRef, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { Chat } from '../../models/chat';
import { Message } from '../../models/message';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css']
})
export class ChatContainerComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild("scroll") scroll: ElementRef;
  @Input() chat$: Observable<Chat>;
  messageForm: FormGroup;
  messages: Message[];
  subscription: Subscription;
  public isEmojiPickerVisible: boolean;
  public addEmoji(event: any) {
    this.messageForm.controls["message"].setValue(`${this.messageForm.controls["message"].value}${event.emoji.native}`);
  }
  constructor(private formBuilder: FormBuilder) {
    this.messageForm = this.formBuilder.group({
      message: ["", Validators.required]
    })
  }

  ngAfterViewInit() {
    this.scrollDown();
  }

  ngOnInit(): void {
    this.subscription = this.chat$.subscribe(_ => {
      this.messages = _.messages;
    })
  }

  sendMessage() {
    this.messages.push({
      text: this.messageForm.value.message,
      when: new Date().toLocaleString(),
      from: { id: "me" }
    });

    this.scrollDown();
    this.messageForm.reset();
  }

  private scrollDown() {
    setTimeout(() => {
      this.scroll.nativeElement.scrollTo(0, this.scroll.nativeElement.scrollHeight);
    }, 0);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
