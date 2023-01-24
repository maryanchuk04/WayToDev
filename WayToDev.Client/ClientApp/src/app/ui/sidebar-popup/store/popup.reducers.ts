import {createReducer, on} from "@ngrx/store";
import {PopupStore} from "./popupStore";
import {handleChangePopup} from "./popup.actions";


const initialState: PopupStore = {
  open: false,
  userId: ""
}
export const popupReducers = createReducer(
  initialState,
  on(handleChangePopup, (state, action)=>({...state, open: !state.open, userId: action.id}))
)

