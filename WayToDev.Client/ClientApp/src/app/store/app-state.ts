import {ProfileInterface} from "../profile/store/ProfileStore";
import {PopupStore} from "../ui/sidebar-popup/store/popupStore";

export interface AppState{
  profile: ProfileInterface,
  popup: PopupStore
}
