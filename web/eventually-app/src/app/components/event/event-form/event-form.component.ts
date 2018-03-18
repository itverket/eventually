import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { IEvent } from '../../../interfaces/IEvent';
import { EventService } from '../../../services/event.service';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.scss']
})
export class EventFormComponent implements OnInit {
  private data = {} as IEvent;

  @Input() showCondition: boolean;
  @Output() newEventSaved = new EventEmitter<IEvent>();

  constructor(private eventService: EventService) { }

  ngOnInit() {
  }

  saveEvent() {
    this.eventService.saveEvent(this.data).subscribe(eventId => {
     
      let result = Object.assign({}, this.data);
      result.id = eventId;
      result.createdInThisSession = true;
      this.newEventSaved.emit(result);

      this.data = {} as IEvent;
    });
  }

}
