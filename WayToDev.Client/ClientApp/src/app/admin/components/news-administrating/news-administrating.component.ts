import { Component, OnInit } from '@angular/core';
import { NewsListItem } from '../../models/newsListItem'
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import { CreateNewsComponent } from './create-news/create-news.component';

@Component({
  selector: 'app-news-administrating',
  templateUrl: './news-administrating.component.html',
  styleUrls: ['./news-administrating.component.css']
})
export class NewsAdministratingComponent implements OnInit {
  newsList: NewsListItem[] = [
    {
      id: "1sd12sad1dsad1d",
      title: "This is the cool news",
      date: "12/21/2022",
      image: "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png",
      shortDescription : "Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description..."
    },
    {
      id: "1sd12sad1dsad1d",
      title: "This is the cool news",
      date: "12/21/2022",
      image: "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png",
      shortDescription : "Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description..."
    },
    {
      id: "1sd12sad1dsad1d",
      title: "This is the cool news",
      date: "12/21/2022",
      image: "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png",
      shortDescription : "Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description..."
    },
    {
      id: "1sd12sad1dsad1d",
      title: "This is the cool news",
      date: "12/21/2022",
      image: "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png",
      shortDescription : "Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description..."
    },
    {
      id: "1sd12sad1dsad1d",
      title: "This is the cool news",
      date: "12/21/2022",
      image: "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2022/11/Download-NET-7.png",
      shortDescription : "Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description...Short Description..."
    },
  ];
  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog(): void{
    this.dialog.open(CreateNewsComponent, {

      width: '800px',
    });
  }
}
