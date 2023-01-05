import { Component, Input, OnInit } from '@angular/core';
import { NewsPreview } from '../../../models/newsPreview'
import {News} from "../../models/news";


const MAX_TITLE_LENGTH = 16;
const MAX_TEXT_LENGTH = 100;

@Component({
  selector: 'app-news-preview',
  templateUrl: './news-preview.component.html',
  styleUrls: ['./news-preview.component.css']
})
export class NewsPreviewComponent implements OnInit {
  @Input() news: News;

  ngOnInit(): void {

  }

  private validateLength(line: string, length: number){
    if(line.length > length){
      return line.slice(0, length) + "...";
    }
    return line;
  }

}
