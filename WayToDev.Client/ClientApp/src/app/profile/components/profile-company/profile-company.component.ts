import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {Company} from "../../../models/company";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../../store/appState";
import {companySelector} from "../store/company.selectors";
import {getCurrentCompany} from "../store/company.actions";

@Component({
  selector: 'app-profile-company',
  templateUrl: './profile-company.component.html',
  styleUrls: ['./profile-company.component.css']
})
export class ProfileCompanyComponent implements OnInit {
  company$: Observable<Company | null>
  company: Company;
  constructor(private store: Store<AppState>, ) {
    this.store.dispatch(getCurrentCompany());
    this.company$ = this.store.pipe(select(companySelector));
    this.company$.subscribe(_=>{
      if(_ != null)
        this.company = _;
    })
  }

  ngOnInit(): void {
    console.log(this.company)
  }

}
