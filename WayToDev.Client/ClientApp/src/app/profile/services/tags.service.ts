import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {TechItem} from "../../models/techItem";

@Injectable({
  providedIn: 'root'
})
export class TagsService {
  apiUrl: string = environment.basePath + "tags";
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<TechItem[]>{
    return this.httpClient.get<TechItem[]>(this.apiUrl);
  }
}
