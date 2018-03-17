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

  saveEvent(event: IEvent): Observable<IEvent> {
    event.createdInThisSession = true;
    this.events.unshift(event);
    return this.apiService.get(this.url);
  }

  private events: IEvent[] = [
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Kos og moro - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
      startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 11, 20, 0, 0),
      createdInThisSession: false
    },
    {
      title: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Vi spiser pizza',
      startTime: new Date(2018, 10, 10, 15, 0, 0),
      endTime: new Date(2018, 10, 12, 20, 0, 0),
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
