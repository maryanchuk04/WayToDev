import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthModule } from '../auth.module';
import { LoginModel } from '../components/models/loginModel';
import { RegistrationModel } from '../components/models/registrationModel';

@Injectable({
  providedIn: "root"
})

export class AuthService {
  apiUrl: string = "https://localhost:7218/api/authenticate";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private httpClient: HttpClient) { }

  registration(registrationModel: RegistrationModel): Observable<any>{
    return this.httpClient.post(this.apiUrl + "/registration", registrationModel);
  }

  authenticate(loginModel: LoginModel){
    return this.httpClient.post(this.apiUrl , loginModel);
  }

}
