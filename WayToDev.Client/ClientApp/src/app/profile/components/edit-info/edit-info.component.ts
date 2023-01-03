import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {User} from "../../models/user";
import {TechItem} from "../../../models/techItem";
import {TagsService} from "../../services/tags.service";
import {Observable} from "rxjs";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../../Store/AppState";
import {userSelector} from "../../store/profile.selectors";
import * as ProfileActions from "../../store/profile.actions";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-edit-info',
  templateUrl: './edit-info.component.html',
  styleUrls: ['./edit-info.component.css']
})
export class EditInfoComponent implements OnInit {
  profileForm!: FormGroup;
  user$: Observable<User | null>
  user: User;
  tags: TechItem[];

  constructor(private techService: TagsService, private store: Store<AppState>, private formBuilder: FormBuilder) {
    this.store.dispatch(ProfileActions.getCurrentUser());
    this.user$ = this.store.pipe(select(userSelector));
    this.user$.subscribe(_=> {
      if(_ !== null) {
        this.user = _;
        this.profileForm = this.formBuilder.group(
          {
            userName: [this.user.userName],
            firstName : [this.user.firstName, [Validators.required]],
            lastName: [this.user.lastName, []],
            email: [this.user.email,[]],
            birthday: [this.user.birthday.substring(0,10), ],
            imageUrl: [this.user.imageUrl],
            bio: [""]
          });
      }
    });
  }

  ngOnInit(): void {
    this.techService.getAll().subscribe(_=>{
      this.tags = _;
    })
  }

  removeTag(item: TechItem): void{
    const tagArray = this.user?.tags.filter(x=>x.id !== item.id);
    if(!tagArray){
      this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [] }));
      return;
    }
    this.store.dispatch(ProfileActions.updateTagsForUser({ tags : tagArray }));
    this.tags = [...this.tags, item]
  }

  addTag(item: TechItem): void{
    if(this.user?.tags.length == 0){
      this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [item] }));
      return;
    }
    this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [...this.user?.tags, item] }));
    this.tags = this.tags.filter(_=>_.id !== item.id);
  }

  saveInfo(): void{
    console.log(this.profileForm.value)
    this.user = {
      ...this.user,
      userName : this.profileForm.value.userName,
      firstName : this.profileForm.value.firstName,
      lastName : this.profileForm.value.lastName,
      birthday : this.profileForm.value.birthday,
      email: this.profileForm.value.email
    }
    this.store.dispatch(ProfileActions.updateCurrentUser({ user : this.user }))
  }

  cancel():void{
    this.profileForm.reset();
  }
}
