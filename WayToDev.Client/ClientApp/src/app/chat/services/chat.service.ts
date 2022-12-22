import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'
import { Chat } from '../models/chat'

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor() { }

  getChatById(id: string): Chat{
    return this.tempChat;
  }

  private tempChat: Chat = {
    title: "Elon Mask",
    id: "chatId",
    messages: [
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "elon",
          userName: "Elon Mask",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "me",
          userName: "Maks",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "elon",
          userName: "Elon Mask",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you? What are u doing?",
        id: "messageId",
        from: {
          id: "me",
          userName: "Maks",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "elon",
          userName: "Elon Mask",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "me",
          userName: "Maks",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "elon",
          userName: "Elon Mask",
        },
        when: "12/22/2022 12:32"
      },
      {
        text: "Hello how are you?",
        id: "messageId",
        from: {
          id: "me",
          userName: "Maks",
        },
        when: "12/22/2022 12:32"
      }
    ],
    image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg"
  }

}
