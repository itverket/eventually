import { Component, OnInit, ViewChild } from '@angular/core';
import { EventService } from '../../../services/event.service';
import { IEvent } from '../../../interfaces/IEvent';
import { SidebarMenuComponent} from '../../layout/sidebar-menu/sidebar-menu.component'

@Component({
  selector: 'app-event-gallery',
  templateUrl: './event-gallery.component.html',
  styleUrls: ['./event-gallery.component.scss']
})
export class EventGalleryComponent implements OnInit {

@ViewChild('sidebarmenu') sidebarMenu : SidebarMenuComponent;

  private data: IEvent[];
  constructor(private eventService: EventService) { }

  ngOnInit() {
    this.eventService.getEvents().subscribe((events) =>{
this.data = events;
    });

  }
    newEventSaved(event: IEvent): void{
      this.data.unshift(event);
      this.sidebarMenu.show = false;
    }

}
