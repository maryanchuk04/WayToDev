import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { map, mergeMap } from "rxjs";
import { ChatService } from "../services/chat.service";
import * as ChatActions from './chat.actions';

@Injectable()
export class ChatEffects{
    getChat$ = createEffect(()=>
        this.actions$.pipe(
            ofType(ChatActions.getChat),
            map(action => action),
            mergeMap(({roomId, userId})=>
                this.chatService.getChatById(roomId, userId).pipe(
                    map(chat => ChatActions.getChatSuccess({ chat }))
                )
            )
        )
    )

    getCurrentUserChats$ = createEffect(()=>
        this.actions$.pipe(
            ofType(ChatActions.getCurrentUserChatsPreview),
            mergeMap(()=>{
                console.log("work")
                return this.chatService.getChatsPreview().pipe(
                    map(chats => ChatActions.currentUserChatsPreviewSuccess({ chatsPreview: chats }))
                )
            }
                
            )
        )
    )

    

    constructor(private actions$: Actions, private chatService: ChatService){
    }
}