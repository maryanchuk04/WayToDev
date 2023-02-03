import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatsPageComponent } from './components/chats-page/chats-page.component';
import {ChatContainerComponent} from "./components/chat-container/chat-container.component";

const chatRoutes: Routes = [
  {
    path: 'chats',
    component: ChatsPageComponent,
    children:[
      { path: ":roomId/:userId", component: ChatContainerComponent}
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(chatRoutes)],
  exports: [RouterModule]
})
export class ChatRoutingModule { }
