import { Component, OnInit } from '@angular/core';
import { FeedbackRequest} from '../../models/feedbackRequest'

@Component({
  selector: 'app-feedback-administrating',
  templateUrl: './feedback-administrating.component.html',
  styleUrls: ['./feedback-administrating.component.css']
})
export class FeedbackAdministratingComponent implements OnInit {
  feedbacks: FeedbackRequest[] = [
    {
      id: "21103021201301adasfkdasd",
      text : "Hello cool company",
      rate : 5,
      company: {
        name : "SigmaSoftware",
        logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png"
      },
      fromUser: {
        userName: "MaksMaryanchuk",
        image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
      },
      isApproved : false
    },
    {
      id: "21103021201301adasfkdasd",
      text : "Hello cool company",
      rate : 5,
      company: {
        name : "SigmaSoftware",
        logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png"
      },
      fromUser: {
        userName: "MaksMaryanchuk",
        image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
      },
      isApproved : false
    },
    {
      id: "21103021201301adasfkdasd",
      text : "Hello cool company",
      rate : 5,
      company: {
        name : "SigmaSoftware",
        logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png"
      },
      fromUser: {
        userName: "MaksMaryanchuk",
        image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
      },
      isApproved : false
    },
    {
      id: "21103021201301adasfkdasd",
      text : "Hello cool company",
      rate : 5,
      company: {
        name : "SigmaSoftware",
        logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png"
      },
      fromUser: {
        userName: "MaksMaryanchuk",
        image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
      },
      isApproved : false
    },
    {
      id: "21103021201301adasfkdasd",
      text : "Hello cool company",
      rate : 5,
      company: {
        name : "SigmaSoftware",
        logo: "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/v1496219193/uzjqe0jsl1yww081xrgl.png"
      },
      fromUser: {
        userName: "MaksMaryanchuk",
        image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
      },
      isApproved : false
    }
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
