import { Injectable } from '@angular/core';
import { IEvent } from '../interfaces/IEvent';
import { ApiClient } from '../services/api-client';
import { Observable } from 'rxjs';


@Injectable()
export class EventService {
  private url = 'event';
  
  constructor(private apiService: ApiClient<IEvent>) { }

  getEvents(): Observable<IEvent[]> {
    return this.apiService.getList(this.url);
  }

  saveEvent(event: IEvent): Observable<string> {
    return this.apiService.post(this.url, event);
  }

  private events: IEvent[] = [
    {
      name: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Kos og moro - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
      starts: new Date(2018, 10, 10, 15, 0, 0),
      ends: new Date(2018, 10, 11, 20, 0, 0),
      createdInThisSession: false
    },
    {
      name: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'Vi spiser pizza',
      starts: new Date(2018, 10, 10, 15, 0, 0),
      ends: new Date(2018, 10, 12, 20, 0, 0),
      createdInThisSession: false
    },
    {
      name: 'Fagkveld',
      location: 'Fjellveien 32',
      description: 'koding',
      starts: new Date(2018, 10, 10, 15, 0, 0),
      ends: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      name: 'Juletrefest',
      location: 'Oslo 22',
      description: 'vi planlegger julen',
      starts: new Date(2018, 10, 10, 15, 0, 0),
      ends: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
    {
      name: 'Månelanding',
      location: 'Månen',
      description: 'dette blir gøy',
      starts: new Date(2018, 10, 10, 15, 0, 0),
      ends: new Date(2018, 10, 10, 20, 0, 0),
      createdInThisSession: false
    },
  ];
}
