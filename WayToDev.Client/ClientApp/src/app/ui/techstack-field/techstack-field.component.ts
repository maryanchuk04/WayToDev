import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TechItem} from "../../models/techItem";
import {TagsService} from "../../profile/services/tags.service";
import * as ProfileActions from "../../profile/store/profile.actions";

@Component({
  selector: 'app-techstack-field',
  templateUrl: './techstack-field.component.html',
  styleUrls: ['./techstack-field.component.css']
})
export class TechstackFieldComponent implements OnInit {
  @Input() techStack: TechItem[];
  @Output() deleteEmitter: EventEmitter<TechItem> = new EventEmitter<TechItem>();
  constructor() {
  }

  ngOnInit(): void {

  }

  delete = (item: TechItem): any =>{
    this.deleteEmitter.emit(item);
  }
}
