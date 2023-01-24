import {Component, Input, OnChanges, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {DomSanitizer} from "@angular/platform-browser";

@Component({
  selector: 'app-svg-icon',
  templateUrl: './svg-icon.component.html',
  styleUrls: ['./svg-icon.component.css']
})
export class SvgIconComponent implements OnChanges {
  @Input()
  public name?: string;

  public svgIcon: any;
  constructor(private httpClient: HttpClient, private sanitizer: DomSanitizer) { }

  ngOnChanges(): void {
    if (!this.name) {
      this.svgIcon = '';
      return;
    }
    this.httpClient
      .get(`assets/svgs/${this.name}.svg`, { responseType: 'text' })
      .subscribe(value => {
        this.svgIcon = this.sanitizer.bypassSecurityTrustHtml(value);
      });
  }

}
