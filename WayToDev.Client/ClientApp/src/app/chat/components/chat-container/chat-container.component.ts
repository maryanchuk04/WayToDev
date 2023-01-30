import {
  Component,
  OnInit,
  ViewChild,
  AfterViewInit,
  ElementRef,
  OnDestroy,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { Chat } from '../../models/chat';
import { Message } from '../../models/message';
import { ChatService } from '../../services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css'],
})
export class ChatContainerComponent
  implements OnInit, AfterViewInit, OnDestroy
{
  @ViewChild('scroll') scroll: ElementRef;
  chat$: Observable<Chat>;
  messageForm: FormGroup;
  messages: Message[];
  subscription: Subscription;
  isEmojiPickerVisible: boolean;

  public addEmoji(event: any) {
    this.messageForm.controls['message'].setValue(
      `${this.messageForm.controls['message'].value}${event.emoji.native}`
    );
  }

  constructor(
    private formBuilder: FormBuilder,
    private chatService: ChatService,
    private router: ActivatedRoute
  ) {
    this.messageForm = this.formBuilder.group({
      message: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern('[\\S]{1,}[\\S\\s]*|[\\s]*[\\S]{1,}[\\S\\s]*'),
        ]),
      ],
    });
    this.router.params.subscribe((params) => {
      this.chat$ = this.chatService.getChatById(params['id']);
      this.scrollDown();
    });
  }

  ngAfterViewInit() {
    this.scrollDown();
  }

  ngOnInit(): void {
    this.subscription = this.chat$.subscribe((_) => {
      this.messages = _.messages;
    });
  }

  sendMessage() {
    this.messages.push({
      text: this.messageForm.value.message.trim(),
      when: new Date().toLocaleString(),
      from: { id: 'me' },
    });

    this.scrollDown();
    this.messageForm.reset();
  }

  private scrollDown() {
    setTimeout(() => {
      this.scroll.nativeElement.scrollTo(
        0,
        this.scroll.nativeElement.scrollHeight + 100
      );
    }, 100);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
