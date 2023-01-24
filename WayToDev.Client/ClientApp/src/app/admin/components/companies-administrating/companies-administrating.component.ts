import { Component, OnInit } from '@angular/core';
import { CompanyListItem } from '../../models/companyListItem'
@Component({
  selector: 'app-companies-administrating',
  templateUrl: './companies-administrating.component.html',
  styleUrls: ['./companies-administrating.component.css']
})
export class CompaniesAdministratingComponent implements OnInit {
  companiesList: CompanyListItem[] = [
    {
      id: "2130312mqwdmasmdw013",
      logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png",
      name: "SigmaSoftware",
      isDisabled: false
    },
    {
      id: "2130312mqwdmasmdw013",
      logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png",
      name: "SigmaSoftware",
      isDisabled: false
    },
    {
      id: "2130312mqwdmasmdw013",
      logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png",
      name: "SigmaSoftware",
      isDisabled: true
    },
    {
      id: "2130312mqwdmasmdw013",
      logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png",
      name: "SigmaSoftware",
      isDisabled: false
    },
]
  constructor() {
  }

  ngOnInit(): void {
  }

}
