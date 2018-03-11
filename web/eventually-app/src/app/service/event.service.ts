import { Injectable } from '@angular/core';
import { IEvent } from '../interfaces/IEvent';

@Injectable()
export class EventService {

  constructor() { }


  private events: IEvent[] = [
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Kos og moro',
      endTime: new Date(),
      startTime: new Date(),
    },
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Vi spiser pizza',
      endTime: new Date(),
      startTime: new Date(),
    },
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'koding',
      endTime: new Date(),
      startTime: new Date(),
    },
    {
      title: 'Juletrefest',
      location: 'Oslo 22',
      description: 'vi planlegger julen',
      endTime: new Date(),
      startTime: new Date(),
    },
    {
      title: 'Månelanding',
      location: 'Månen',
      description: 'dette blir gøy',
      endTime: new Date(),
      startTime: new Date(),
    },
  ];

  getEvents(): IEvent[] {
    return this.events;
  }

  saveEvent(event: IEvent) {
    this.events.push(event);
  }

}
