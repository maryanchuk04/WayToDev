import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {BehaviorSubject, catchError, Observable, throwError} from 'rxjs';
import { LoginModel } from '../models/loginModel';
import { RegistrationModel } from '../models/registrationModel';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

const BASE_PATH = environment.basePath;
@Injectable({
  providedIn: 'root',
})

export class AuthService {
  private authenticated$: BehaviorSubject<boolean> = new BehaviorSubject(!!localStorage.getItem("token"));
  apiUrl: string = `${BASE_PATH}authenticate`;
  httpOptions: Object = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
    responseType: 'json',
    observe: 'response',
  };

  constructor(
    private httpClient: HttpClient,
    public jwtHelper: JwtHelperService
  ) {}

  registration(registrationModel: RegistrationModel): Observable<any> {
    return this.httpClient
      .post<any>(
        this.apiUrl + '/registration',
        registrationModel,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  authenticate(loginModel: LoginModel) {
    return this.httpClient
      .post<any>(this.apiUrl, loginModel, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }


  public isAuthenticatedObs(): Observable<boolean> {
    return this.authenticated$.asObservable();
  }

  setAuthenticated(authenticated: boolean) {
    this.authenticated$.next(authenticated);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.log(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }

  unAuthorize(): void{
    localStorage.removeItem("token");
    localStorage.removeItem("role");
    this.httpClient.get('this.apiUrl/unauthorize');
  }

  confirmEmail(accountId: string, token: string): Observable<any>{
    return this.httpClient.get<any>(`${this.apiUrl}/verify/${accountId}/${token}`, this.httpOptions);
  }
}
