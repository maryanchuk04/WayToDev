import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { LoginModel } from '../models/loginModel';
import { RegistrationModel } from '../models/registrationModel';
import { AlertService } from 'src/app/ui/alert/alert.service';


@Injectable({
  providedIn: "root"
})

export class AuthService {
  apiUrl: string = "https://localhost:7218/api/authenticate";
  httpOptions : Object = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
    responseType: 'json',
    observe : "response"
  };

  constructor(
    private httpClient: HttpClient,
    private alertService: AlertService) { }

  registration(registrationModel: RegistrationModel): Observable<any>{

    return this.httpClient.post<any>(this.apiUrl + "/registration", registrationModel, this.httpOptions).pipe(catchError(this.handleError));
  }

  authenticate(loginModel: LoginModel){
    return this.httpClient.post<any>(this.apiUrl , loginModel, this.httpOptions).pipe(catchError(this.handleError))
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.log(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  confirmEmail(token: string): Observable<any>{
    return this.httpClient.get<any>(`${this.apiUrl}/verify/${token}`, this.httpOptions);
  }
}
