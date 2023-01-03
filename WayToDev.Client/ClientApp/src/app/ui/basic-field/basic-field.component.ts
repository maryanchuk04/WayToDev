import {Component, Input, OnInit} from '@angular/core';
import {InputType} from "@coreui/angular";

@Component({
  selector: 'app-basic-field',
  templateUrl: './basic-field.component.html',
  styleUrls: ['./basic-field.component.css']
})
export class BasicFieldComponent implements OnInit {
  @Input() type: InputType = 'text';
  @Input() placeholder: string = "";
  @Input() defaultValue: string = "";
  @Input('class') classes: string;
  constructor() { }

  ngOnInit(): void {
  }

}
