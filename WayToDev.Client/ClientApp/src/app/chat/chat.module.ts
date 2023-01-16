import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiModule } from '../ui/ui.module';
import { ChatsPageComponent } from './components/chats-page/chats-page.component';
import { ChatRoutingModule } from './chat-routing.module'
import { MatSidenavModule } from '@angular/material/sidenav';
import { ChatListItemComponent } from './components/chat-list-item/chat-list-item.component';
import { ChatContainerComponent } from './components/chat-container/chat-container.component';
import { MessageComponent } from './components/message/message.component'
import { MatButtonModule } from '@angular/material/button';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {PickerModule} from "@ctrl/ngx-emoji-mart";
import {AutosizeModule} from "ngx-autosize";

@NgModule({
  declarations: [
    ChatsPageComponent,
    ChatListItemComponent,
    ChatContainerComponent,
    MessageComponent
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    UiModule,
    MatSidenavModule,
    MatButtonModule,
    ReactiveFormsModule,
    PickerModule,
    FormsModule,
    AutosizeModule
  ]
})
export class ChatModule { }