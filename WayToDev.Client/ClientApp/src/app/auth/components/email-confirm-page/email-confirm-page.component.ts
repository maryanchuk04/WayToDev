import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  templateUrl: './email-confirm-page.component.html',
  styleUrls: ['./email-confirm-page.component.css']
})
export class EmailConfirmPageComponent implements OnInit {
  success: boolean = false;
  constructor(private authService: AuthService, private actRouter: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.actRouter.params.subscribe(parameter => {
      this.authService.confirmEmail(parameter.token).subscribe( _ => {
        console.log(_);
        if(_.status == 200){
          this.router.navigate(["/profile"]);
        }
      });
    })
  }
}
