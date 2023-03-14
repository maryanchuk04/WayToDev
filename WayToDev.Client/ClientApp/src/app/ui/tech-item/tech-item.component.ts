import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TechItem} from "../../models/techItem";

@Component({
  selector: 'app-tech-item',
  templateUrl: './tech-item.component.html',
  styleUrls: ['./tech-item.component.css']
})
export class TechItemComponent implements OnInit {
  @Input() showDelete: boolean = false;
  @Input() item: TechItem;
  @Input() close: (item: TechItem) => any;
  constructor() { }
  ngOnInit(): void {
  }

  delete(){
    this.close(this.item);
  }

}
