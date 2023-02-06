import { createSelector } from "@ngrx/store";
import { AppState } from "src/app/store/app-state";

export const selectFeature = (state: AppState) => state.chat;

export const chatSelector = createSelector(
    selectFeature,
    (state) => state.chat
)

export const chatsPreviewSelector = createSelector(
    selectFeature,
    (state) => state.chatsPreview
)

export const chatsMessagesSelector = createSelector(
    selectFeature,
    (state) => state.chat?.messages
)