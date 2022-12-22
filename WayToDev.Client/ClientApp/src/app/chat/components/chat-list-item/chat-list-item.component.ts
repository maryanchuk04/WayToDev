import { Component, OnInit, Input } from '@angular/core';
import { ChatPreview } from '../../models/chatPreview';

@Component({
  selector: 'app-chat-list-item',
  templateUrl: './chat-list-item.component.html',
  styleUrls: ['./chat-list-item.component.css']
})
export class ChatListItemComponent implements OnInit {
  @Input() chatItem: ChatPreview;

  constructor() { }

  ngOnInit(): void {
  }

}
