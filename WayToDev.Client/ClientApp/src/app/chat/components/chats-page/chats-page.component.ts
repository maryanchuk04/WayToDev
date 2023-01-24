import { Component, OnInit } from '@angular/core';
import { ChatPreview } from '../../models/chatPreview'
import { Chat } from '../../models/chat'
import { ChatService } from '../../services/chat.service'
import { Observable } from 'rxjs';
import {Router} from "@angular/router";
@Component({
  selector: 'app-chats-page',
  templateUrl: './chats-page.component.html',
  styleUrls: ['./chats-page.component.css']
})
export class ChatsPageComponent implements OnInit {
  loading: boolean = false;
  chatsList: ChatPreview[] = []
  constructor(private chatService: ChatService, private router: Router) {
    chatService.getChats().subscribe(_=>{
      if(_ != null){
        _.map(x=>{
          this.chatsList.push({ id: x.id, title: x.title, lastMessage: x.messages[0]})
        })
      }
    })
  }

  ngOnInit(): void {
  }


}
