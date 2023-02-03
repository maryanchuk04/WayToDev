import { Chat } from "../models/chat";
import { ChatPreview } from "../models/chatPreview";

export interface ChatStore {
    chat: Chat | null;
    chatsPreview: ChatPreview[] | []
}