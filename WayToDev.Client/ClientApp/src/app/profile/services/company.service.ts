import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Company} from "../../models/company";
const BASE_PATH = environment.basePath;
@Injectable({
  providedIn: 'root'
})

export class CompanyService {
  apiUrl: string = `${BASE_PATH}company`;

  constructor(private http: HttpClient) {
    http.options(this.apiUrl);
  }

  getCurrentCompany(): Observable<Company> {
    return this.http.get<Company>(this.apiUrl, {
      headers : {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem("token")}`
      }
    });
  }
}
