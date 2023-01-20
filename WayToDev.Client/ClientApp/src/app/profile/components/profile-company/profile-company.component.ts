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
import {FormBuilder, FormGroup} from "@angular/forms";
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
  companyForm: FormGroup;

  constructor(private store: Store<AppState>, private techService: TagsService, private fb: FormBuilder) {
    this.store.dispatch(getCurrentCompany());
    this.company$ = this.store.pipe(select(companySelector));
    this.company$.subscribe(_=>{
      if(_ != null){
        this.company = _;
        this.companyForm = fb.group({
          companyName: this.company.companyName,
          imgUrl: this.company.imageUrl,
          description: this.company.description,
          email: this.company.email,
          countOfWorkers: this.company.countOfWorkers
        });
      }

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

  save(){
    if(this.companyForm.valid){
      this.company = {
        ...this.company,
        ...this.companyForm.value
      }
      this.store.dispatch(ProfileActions.updateCurrentCompany({company : this.company}))
    }
  }
}
