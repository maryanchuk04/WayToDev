import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders, HttpParamsOptions} from "@angular/common/http";
import {Company} from "../../models/company";
const BASE_PATH = environment.basePath;
@Injectable({
  providedIn: 'root'
})

export class CompanyService {
  apiUrl: string = `${BASE_PATH}company`;
  private headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("token")}`
  });
  constructor(private http: HttpClient) {
  }

  getCurrentCompany(): Observable<Company> {
    return this.http.get<Company>(this.apiUrl, { headers: this.headers});
  }

  updateCurrentCompany(company: Company): Observable<any>{
    return this.http.post<any>(this.apiUrl, company, { headers: this.headers})
  }
}
