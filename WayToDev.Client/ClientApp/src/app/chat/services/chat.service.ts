import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throws } from 'assert';
import { Observable, tap, zip } from 'rxjs'
import { Chat } from '../models/chat'

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private httpClient: HttpClient) { }

  getChatById(id: string): Observable<Chat>{
    return this.httpClient.get<Chat>("/assets/tempObj.json").pipe(tap(x=>console.log(x)));
  }
}
