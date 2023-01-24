import { Component, OnInit, Input } from '@angular/core';
import { CompanyListItem } from 'src/app/admin/models/companyListItem';

@Component({
  selector: 'app-company-list-item',
  templateUrl: './company-list-item.component.html',
  styleUrls: ['./company-list-item.component.css']
})
export class CompanyListItemComponent implements OnInit {
  @Input() company: CompanyListItem;
  constructor() { }

  ngOnInit(): void {
  }

}
