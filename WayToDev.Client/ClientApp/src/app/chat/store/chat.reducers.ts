import { createReducer, on } from "@ngrx/store";
import { ChatStore } from "./ChatStore";
import * as ChatActions from './chat.actions';

export const initialState: ChatStore = {
    chat: null,
    chatsPreview: []
}


export const chatReducers = createReducer(
    initialState,
    on(ChatActions.getChat, (state) => state),
    on(ChatActions.getChatSuccess, (state, action) => ({ ...state, chat: action.chat })),
    on(ChatActions.getCurrentUserChatsPreview, state => state),
    on(ChatActions.currentUserChatsPreviewSuccess, (state, action) => ({ ...state, chatsPreview: action.chatsPreview })),
    on(ChatActions.sendMessageToChat, (state, action)=>({...state, chat : {...state.chat!, messages: [...state.chat!.messages, action.message] }}))
);