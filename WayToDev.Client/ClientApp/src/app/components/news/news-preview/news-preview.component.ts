import { Component, Input, OnInit } from '@angular/core';
import { NewsPreview } from '../../models/newsPreview';

const MAX_TITLE_LENGTH = 16;
const MAX_TEXT_LENGTH = 100;

@Component({
  selector: 'app-news-preview',
  templateUrl: './news-preview.component.html',
  styleUrls: ['./news-preview.component.css']
})
export class NewsPreviewComponent implements OnInit {
  @Input() news!: NewsPreview;

  constructor() { }

  ngOnInit(): void {
    this.news.title = this.validateLength(this.news.title, MAX_TITLE_LENGTH);
    this.news.text = this.validateLength(this.news.text, MAX_TEXT_LENGTH);
    console.log(this.news);
  }

  private validateLength(line: string, length: number){
    if(line.length > length){
      return line.slice(0, length) + "...";
    }
    return line;
  }

}
