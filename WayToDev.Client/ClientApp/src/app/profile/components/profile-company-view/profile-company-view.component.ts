import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {Company} from "../../../models/company";
import {ActivatedRoute} from "@angular/router";
import {CompanyService} from "../../services/company.service";

@Component({
  selector: 'app-profile-company-view',
  templateUrl: './profile-company-view.component.html',
  styleUrls: ['./profile-company-view.component.css']
})
export class ProfileCompanyViewComponent implements OnInit {
  company$: Observable<Company>;
  vacancies$: Observable<any>;
  constructor(private route: ActivatedRoute, private companyService: CompanyService) {
    this.route.params.subscribe(_=>{
      this.company$ = this.companyService.getCompanyById(_.id);
      //add request for get company vacancies
    })
  }

  ngOnInit(): void {
  }

}
