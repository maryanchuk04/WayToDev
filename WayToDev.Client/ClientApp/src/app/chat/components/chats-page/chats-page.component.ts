import { Component, OnInit, ViewChild,AfterViewInit, OnDestroy } from '@angular/core';
import { ChatPreview } from '../../models/chatPreview';
import { SignalrService } from '../../services/signalr.service';
import { MatDialog } from '@angular/material/dialog';
import { ChatService } from '../../services/chat.service';
import { select, State, Store } from '@ngrx/store';
import { AppState } from 'src/app/store/app-state';
import { getCurrentUserChatsPreview } from '../../store/chat.actions';
import { chatsPreviewSelector } from '../../store/chat.selector';
import { map, Observable } from 'rxjs';


@Component({
  selector: 'app-chats-page',
  templateUrl: './chats-page.component.html',
  styleUrls: ['./chats-page.component.css'],
})
export class ChatsPageComponent implements OnInit,AfterViewInit, OnDestroy {
  chats$: Observable<ChatPreview[]>;

  constructor(
    chatService: ChatService,
    private signalr: SignalrService,
    private dialog: MatDialog,
    private store: Store<AppState>
  ) {
    this.store.dispatch(getCurrentUserChatsPreview());
    this.chats$ = this.store.pipe(select(chatsPreviewSelector)); 
  }
  ngOnDestroy(): void {
  }

  ngOnInit(): void {
   
  }

  ngAfterViewInit(): void {
  }

}
