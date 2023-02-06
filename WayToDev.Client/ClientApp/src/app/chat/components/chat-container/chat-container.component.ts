import {
	Component,
	OnInit,
	ViewChild,
	AfterViewInit,
	ElementRef,
	OnDestroy,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { Chat } from '../../models/chat';
import { ActivatedRoute, Router } from '@angular/router';
import { SignalrService } from '../../services/signalr.service';
import { select, Store } from '@ngrx/store';
import { AppState } from 'src/app/store/app-state';
import { getChat } from '../../store/chat.actions';
import { chatSelector } from '../../store/chat.selector';
import { TokenService } from 'src/app/services/token.service';

@Component({
	selector: 'app-chat-container',
	templateUrl: './chat-container.component.html',
	styleUrls: ['./chat-container.component.css'],
})
export class ChatContainerComponent
	implements OnInit, AfterViewInit, OnDestroy {
	@ViewChild('scroll') scroll: ElementRef;
	chat$: Observable<Chat | null>;
	messageForm: FormGroup;
	subscription: Subscription;
	isEmojiPickerVisible: boolean;
	chatId: string;
	userId: string = this.service.getUserId();

	public addEmoji(event: any) {
		this.messageForm.controls['message'].setValue(
			`${this.messageForm.controls['message'].value}${event.emoji.native}`
		);
	}

	constructor(
		private formBuilder: FormBuilder,
		private router: ActivatedRoute,
		private signalr: SignalrService,
		private store: Store<AppState>,
		private service: TokenService,
	) {
		this.buildForm();

		this.router.params.subscribe((params) => {
			this.store.dispatch(getChat({ roomId: params['roomId'], userId: params['userId'] }));

			this.chat$ = this.store.pipe(select(chatSelector));

			this.scrollDown();
			this.chatId = params.roomId;
		});
	}

	ngAfterViewInit() {
		this.scrollDown();
	}

	ngOnInit(): void {
	}

	sendMessage() {
		this.signalr.sendMessage(this.chatId, this.messageForm.value.message.trim())
		this.scrollDown();
		this.messageForm.reset();
	}

	private scrollDown() {
		setTimeout(() => {
			this.scroll?.nativeElement.scrollTo(
				0,
				this.scroll?.nativeElement.scrollHeight + 100
			);
		}, 100);
	}

	ngOnDestroy(): void {
		this.signalr.disconnectFromRoom(this.chatId);
	}

	private buildForm() {
		this.messageForm = this.formBuilder.group({
			message: [
				'',
				Validators.compose([
					Validators.required,
					Validators.pattern('[\\S]{1,}[\\S\\s]*|[\\s]*[\\S]{1,}[\\S\\s]*'),
				]),
			],
		});
	}
}
