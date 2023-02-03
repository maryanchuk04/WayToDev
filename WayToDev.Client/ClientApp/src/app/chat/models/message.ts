import { User } from "src/app/profile/models/user";

export interface Message {
  id: string;
  text: string;
  when: string;
  sender: User;
  senderId: string;
  roomId: string;
}
