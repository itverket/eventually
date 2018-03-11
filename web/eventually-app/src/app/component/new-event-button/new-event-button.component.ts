import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-new-event-button',
  templateUrl: './new-event-button.component.html',
  styleUrls: ['./new-event-button.component.scss']
})
export class NewEventButtonComponent implements OnInit {


  @Input() showCondition: boolean;
  @Output() showConditionChange = new EventEmitter<boolean>();


  constructor() { }

  ngOnInit() {
  }

  toggleShowCondition() {
    this.showCondition = !this.showCondition;
    this.showConditionChange.emit(this.showCondition);
  }

}
