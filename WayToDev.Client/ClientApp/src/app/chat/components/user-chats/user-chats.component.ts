import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChatPreview } from '../../models/chatPreview';
import { ChatService } from '../../services/chat.service';
import { SignalrService } from '../../services/signalr.service';

@Component({
  selector: 'app-user-chats',
  templateUrl: './user-chats.component.html',
  styleUrls: ['./user-chats.component.css']
})
export class UserChatsComponent implements OnInit {
  @Input() chats: ChatPreview[];

  constructor(private signalR: SignalrService, private router: Router) {
    this.signalR.startConnection().then( ()=>{
      this.signalR.connectToUserRooms(this.chats.map(chat => chat.id));
    })
  }

  ngOnInit(): void {
  }

}
