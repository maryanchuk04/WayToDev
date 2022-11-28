import { Component, OnInit } from '@angular/core';
import { NewsPreview } from '../../../models/newsPreview';

@Component({
  selector: 'app-all-news-page',
  templateUrl: './all-news-page.component.html',
  styleUrls: ['./all-news-page.component.css']
})
export class AllNewsPageComponent implements OnInit {
  newsList: NewsPreview[] = [
    {
      id : "3123013",
      title: "Super puper news",
      text : "<b>.NET 7</b> brings your apps increased performance and new features for C# 11/F# 7, .NET MAUI, ASP.NET Core/Blazor, Web APIs, WinForms, WPF and more. With .NET 7, you can also easily containerize your .NET 7 projects, set up CI/CD workflows in GitHub actions, and achieve cloud-native observability.",
      image : "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png"
    }
  ]

  constructor() {
    for (let index = 0; index < 9; index++) {
      this.newsList.push(this.newsList[0]);
    }
  }

  ngOnInit(): void {
  }



}
