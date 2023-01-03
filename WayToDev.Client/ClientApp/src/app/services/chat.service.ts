import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private connection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7218/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

  constructor(private http: HttpClient) {
    this.connection.onclose(async () => {
      await this.start();
    });
    this.connection.on("ReceiveOne", () => { console.log("") });
    this.connection.on("SendMessage",(res: any)=>{console.log(res)})
    this.start();
  }

  public async start() {
    try {
      await this.connection.start();
      console.log("connected");
    } catch (err) {
      console.log(err);
      setTimeout(() => this.start(), 5000);
    }
  }

  public async sendMessage(){
    await this.connection.invoke("SendMessage", "2e00df13-fabc-4ca8-a901-e830cec78601", "hellp");
  }
}
