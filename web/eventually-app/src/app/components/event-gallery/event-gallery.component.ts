import { Component, OnInit } from '@angular/core';
import { EventService } from '../../service/event.service';
import { IEvent } from '../../interfaces/IEvent';

@Component({
  selector: 'app-event-gallery',
  templateUrl: './event-gallery.component.html',
  styleUrls: ['./event-gallery.component.scss']
})
export class EventGalleryComponent implements OnInit {


  private data: IEvent[];
  constructor(private eventService: EventService) { }

  ngOnInit() {
    this.eventService.getEvents().subscribe((events) =>{
this.data = events;
    });
  }

}
