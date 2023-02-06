
import { User } from "src/app/profile/models/user";
import { Message } from "./message";

export interface ChatPreview{
  id: string;
  title: string;
  lastMessage?: Message
  user: User
}
