import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-check-box',
  templateUrl: './check-box.component.html',
  styleUrls: ['./check-box.component.css']
})
export class CheckboxComponent {
  @Input() disabled : boolean;
  @Input() active : boolean;
  @Input() id : string;
  @Output() onToggle = new EventEmitter<void>();

  toggle(){
    this.onToggle.next();
  }
}
