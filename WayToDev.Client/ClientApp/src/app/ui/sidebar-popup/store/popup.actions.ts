import {createAction, props} from "@ngrx/store";


export const handleChangePopup = createAction("[Popup] Change popup", props<{id: string}>());
