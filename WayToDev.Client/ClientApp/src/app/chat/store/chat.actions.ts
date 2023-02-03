import { createAction, props } from "@ngrx/store";
import { create } from "domain";
import { Chat } from "../models/chat";
import { ChatPreview } from "../models/chatPreview";
import { Message } from "../models/message";

export const getCurrentUserChatsPreview = createAction("[CHAT] Get current user chat");

export const currentUserChatsPreviewSuccess = createAction("[CHAT] Get current user chats", props<{chatsPreview : ChatPreview[]}>())

export const getChat = createAction("[CHAT] Get chat", props<{ roomId: string, userId: string}>());

export const getChatSuccess = createAction("[CHAT] Get chat success", props<{ chat: Chat }>())

export const sendMessageToChat = createAction("[CHAT] Send Message", props<{message: Message}>())
 