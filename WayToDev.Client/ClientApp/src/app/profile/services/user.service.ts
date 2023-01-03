import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from "../models/user";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
const BASE_PATH = environment.basePath;
@Injectable({
  providedIn: 'root'
})

export class UserService {
  apiUrl: string = `${BASE_PATH}user`;

  constructor(private http: HttpClient) {
    http.options(this.apiUrl, {
      headers : {
        'Content-Type': 'application/json',
        'Authenticate': `Bearer ${localStorage.getItem("token")}`
      }
    });
  }

  getCurrentUser(): Observable<User>{
   return this.http.get<any>(this.apiUrl);
  }

  updateUserInfo(user: User): Observable<any>{
    return this.http.post<any>(this.apiUrl, user);
  }

}
