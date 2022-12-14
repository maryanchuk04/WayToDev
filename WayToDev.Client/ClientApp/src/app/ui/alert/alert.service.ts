import { HttpErrorResponse } from '@angular/common/http';
import { Injectable, NgZone } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(
    public snackBar: MatSnackBar,
    private readonly zone: NgZone
  ) {}

  handleError(error: Error | HttpErrorResponse): any{
    if (error instanceof HttpErrorResponse) {
      for (var i = 0; i < error.error.length; i++) {
        this.zone.run(() => {
          const snackBar = this.snackBar.open(error.error[i], error.status + ' OK', {
            verticalPosition: 'bottom',
            horizontalPosition: 'center',
            duration: 3000,
          });
          snackBar.onAction().subscribe(() => {
            snackBar.dismiss();
          })
        });
      }
    }
    else{
      console.error(error);
    }
  }
}
