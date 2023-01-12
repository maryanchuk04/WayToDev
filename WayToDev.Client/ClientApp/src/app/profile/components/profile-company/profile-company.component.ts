import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {Company} from "../../../models/company";
import {select, Store} from "@ngrx/store";

import {AppState} from "../../../store/app-state";
import {getCurrentCompany} from "../../store/profile.actions";
import {companySelector} from "../../store/profile.selectors";
import {TagsService} from "../../services/tags.service";
import {Tag} from "../../../models/tag";
import {TechItem} from "../../../models/techItem";
import * as ProfileActions from "../../store/profile.actions";
const variantsOfCount = [
  "<100","100-200", "200-500", "500-1000", "1000-3000",">3000"
]
@Component({
  selector: 'app-profile-company',
  templateUrl: './profile-company.component.html',
  styleUrls: ['./profile-company.component.css']
})
export class ProfileCompanyComponent implements OnInit {
  company$: Observable<Company | null>
  company: Company;
  tags: Tag[];
  variants: string[] = variantsOfCount;
  constructor(private store: Store<AppState>, private techService: TagsService) {
    this.store.dispatch(getCurrentCompany());
    this.company$ = this.store.pipe(select(companySelector));
    this.company$.subscribe(_=>{
      if(_ != null)
        this.company = _;
    })
  }

  ngOnInit(): void {
    this.techService.getAll().subscribe(_=>{
      this.tags = _;
    })
  }

  removeTag(item: TechItem): void{
    const tagArray = this.company.tags.filter(x=>x.id !== item.id);
    if(!tagArray){
      this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [] }));
      return;
    }
    this.store.dispatch(ProfileActions.updateTagsForUser({ tags : tagArray }));
    this.tags = [...this.tags, item]
  }

  addTag(item: TechItem): void{
    if(this.company.tags.length == 0){
      this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [item] }));
      return;
    }
    this.store.dispatch(ProfileActions.updateTagsForUser({ tags : [...this.company?.tags, item] }));
    this.tags = this.tags.filter(_=>_.id !== item.id);
  }

}
