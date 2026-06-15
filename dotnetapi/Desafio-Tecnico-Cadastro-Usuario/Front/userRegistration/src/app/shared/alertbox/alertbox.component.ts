import { Component, OnInit, Input } from '@angular/core';

import { TypeAlert } from './altertMessage';

@Component({
  selector: 'app-alertbox',
  templateUrl: './alertbox.component.html',
  styleUrls: ['./alertbox.component.css']
})
export class AlertboxComponent implements OnInit {
  @Input() message : String;
  @Input() type : TypeAlert;

  constructor() { }

  ngOnInit() {
  }

  isSucessMessage(){
    return this.type === TypeAlert.Success;
  }

  isErrorMessage(){
    return this.type === TypeAlert.Error;
  }
}
