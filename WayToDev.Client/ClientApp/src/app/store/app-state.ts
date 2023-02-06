import { ChatStore } from "../chat/store/ChatStore";
import { NewsStore } from "../news/store/newsStore";
import {ProfileInterface} from "../profile/store/ProfileStore";
import {PopupStore} from "../ui/sidebar-popup/store/popupStore";

export interface AppState{
  profile: ProfileInterface,
  popup: PopupStore,
  chat: ChatStore,
  news: NewsStore
}
