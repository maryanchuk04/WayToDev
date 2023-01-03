import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {User} from "../../models/user";
import {TechItem} from "../../../models/techItem";
import {TagsService} from "../../services/tags.service";
import {Observable} from "rxjs";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../../Store/AppState";
import {userSelector} from "../../store/profile.selectors";
import * as ProfileActions from "../../store/profile.actions";
import {ProfileInterface} from "../../store/ProfileStore";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-edit-info',
  templateUrl: './edit-info.component.html',
  styleUrls: ['./edit-info.component.css']
})
export class EditInfoComponent implements OnInit {
  profileForm: FormGroup;
  user$: Observable<User | null>
  user: User;
  tags: TechItem[];
  @Output() save: EventEmitter<User> = new EventEmitter<User>();
  constructor(private techService: TagsService, private store: Store<AppState>, private fromBuilder: FormBuilder) {
    this.store.dispatch(ProfileActions.getCurrentUser());
    this.profileForm = fromBuilder.group(
      {
        firstName : [this.user?.firstName],
        lastName: [this.user?.lastName],
        email: [this.user?.email],
        birthday: [this.user?.birthday],
        imageUrl: [this.user?.imageUrl],
        bio: [""]
      }
    )
  }
  ngOnInit(): void {
    this.user$ = this.store.pipe(select(userSelector));
    this.user$.subscribe(_=> {
      if(_ !== null) {
        this.user = _;
      }
    });
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

  saveInfo(){
    console.log(this.profileForm)
    this.save.emit(this.user)
  }
}
