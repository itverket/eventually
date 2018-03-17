import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { IEvent } from '../../interfaces/IEvent';
import { EventService } from '../../service/event.service';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.scss']
})
export class EventFormComponent implements OnInit {
  private data = {} as IEvent;

  @Input() showCondition: boolean;
  @Output() showConditionChange = new EventEmitter<void>();

  constructor(private eventService: EventService) { }

  ngOnInit() {
  }

  saveEvent() {
    this.eventService.saveEvent(this.data).subscribe(e => {
      this.showConditionChange.emit();
      this.data = {} as IEvent;
    });
  }

}
