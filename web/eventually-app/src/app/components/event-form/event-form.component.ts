import { Component, OnInit, Input } from '@angular/core';
import { IEvent } from '../../interfaces/IEvent';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.scss']
})
export class EventFormComponent implements OnInit {


  private data = {} as IEvent;

  @Input() showCondition: boolean;

  constructor() { }

  ngOnInit() {
  }

}
