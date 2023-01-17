import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs'
import { Chat } from '../models/chat'

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private httpClient: HttpClient) { }

  getChatById(id: string): Observable<Chat>{
    return this.httpClient.get<Chat[]>("/assets/tempObj.json").pipe(map(x=>x.find(x=>x.id == id) || x[0]));
  }

  getChats(): Observable<Chat[]>{
    return this.httpClient.get<Chat[]>("/assets/tempObj.json").pipe(tap(x=>console.log(x)));
  }
}
