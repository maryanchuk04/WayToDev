import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs'
import { environment } from 'src/environments/environment';
import { Chat } from '../models/chat'
import { ChatPreview } from '../models/chatPreview';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  url: string = `${environment.basePath}chat`;

  constructor(private httpClient: HttpClient) { }

  getChatsPreview(): Observable<ChatPreview[]>{
    return this.httpClient.get<ChatPreview[]>(this.url);
  }

  getChatById(roomId: string, userId: string): Observable<Chat>{
    return this.httpClient.get<Chat>(`${this.url}/${roomId}/${userId}`);
  }
}
