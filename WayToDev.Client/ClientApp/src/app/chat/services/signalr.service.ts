import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { LogLevel } from '@microsoft/signalr';
import { TokenService } from 'src/app/services/token.service';
import { Message } from '../models/message';
import { ChatService } from './chat.service';
import { map, Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store/app-state';
import { sendMessageToChat } from '../store/chat.actions';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl(`${environment.hubPath}?token=${this.tokenService.getToken()}`, {
      accessTokenFactory: () => this.tokenService.getToken()
    })
    .configureLogging(LogLevel.Information)
    .build();

  constructor(private tokenService: TokenService, private chatService: ChatService, private store: Store<AppState>) {
  }

  public startConnection = () => {
    this.hubConnection.on("JoinToRoom", res => {
      console.log("Join", res);
    })

    this.hubConnection.on("ReceiveMessage", (message: Message) => {
      console.log("message", message);
      this.store.dispatch(sendMessageToChat({ message }));
    })
    return this.hubConnection.start();
  }

  public sendMessage(chatId: string, message: string) {
    this.hubConnection.invoke("SendMessage", chatId, message);
  }

  public connectToUserRooms(ids: string[]) {
    console.log(ids)
    this.hubConnection.invoke("JoinToUsersRooms", ids);
  }

  public getChatMessages(roomId: string, userId: string) {
    return this.chatService.getChatById(roomId, userId);
  }
  
  public disconnect(){
    this.hubConnection.stop().then(()=> console.log("Stop"))
  }

  public disconnectFromRoom(id: string){
    this.hubConnection.invoke("DisconnectFromChat", id);
  }
}