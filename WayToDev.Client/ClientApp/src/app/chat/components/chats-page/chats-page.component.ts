import { Component, OnInit } from '@angular/core';
import { ChatPreview } from '../../models/chatPreview'
import { Chat } from '../../models/chat'
import { ChatService } from '../../services/chat.service'
import { Observable } from 'rxjs';
@Component({
  selector: 'app-chats-page',
  templateUrl: './chats-page.component.html',
  styleUrls: ['./chats-page.component.css']
})
export class ChatsPageComponent implements OnInit {
  choosenChat$: Observable<Chat>;
  loading: boolean = false;
  chatsList: ChatPreview[] = [
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
    {
      id: "chatId",
      title: "Elon Mask",
      lastMessage: {
        text: "Hello Maks, how are you?",
        when: "12/22/2022 10:16",
        id: "messageId",
        from: {
          fullName : "Elon Mask",
          image: "https://upload.wikimedia.org/wikipedia/commons/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg",
        }
      }
    },
  ]
  constructor(private chatService: ChatService) { }

  ngOnInit(): void {
  }

  chooseChat(chatItem: any){
    this.loading = true;
    this.choosenChat$ = this.chatService.getChatById("sad");
    this.loading = false;
  }

}
