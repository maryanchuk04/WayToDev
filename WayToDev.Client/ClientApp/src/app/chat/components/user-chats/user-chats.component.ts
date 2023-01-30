import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChatPreview } from '../../models/chatPreview';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-user-chats',
  templateUrl: './user-chats.component.html',
  styleUrls: ['./user-chats.component.css']
})
export class UserChatsComponent implements OnInit {
  chats: ChatPreview[] = [];

  constructor(chatService: ChatService, private router: Router) {
    chatService.getChats().subscribe(_ => {
      if (_ != null) {
        _.map(x => {
          this.chats.push({ id: x.id, title: x.title, lastMessage: x.messages[0] })
        })
      }
    })
  }

  ngOnInit(): void {
  }

}
