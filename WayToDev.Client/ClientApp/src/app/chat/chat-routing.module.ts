import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatsPageComponent } from './components/chats-page/chats-page.component';

const chatRoutes: Routes = [
  { path: "chats", component: ChatsPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(chatRoutes)],
  exports: [RouterModule]
})
export class ChatRoutingModule { }
