import { Injectable } from '@angular/core';
import { IEvent } from '../interfaces/IEvent';
import { ApiClient } from '../service/api-client';
import { Observable } from 'rxjs';


@Injectable()
export class EventService {

  private url = 'events';

  constructor(private apiService: ApiClient<IEvent>) { }

  getEvents(): IEvent[] {
    return this.events;
  }

  saveEvent(event: IEvent) : Observable<IEvent>{
    event.createdInThisSession = true;
    this.events.unshift(event);
    return this.apiService.get(this.url);
  }

  private events: IEvent[] = [
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Kos og moro',
  startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Vi spiser pizza',
      startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'koding',
       startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      title: 'Juletrefest',
      location: 'Oslo 22',
      description: 'vi planlegger julen',
        startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      title: 'Månelanding',
      location: 'Månen',
      description: 'dette blir gøy',
      startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
  ];
}
