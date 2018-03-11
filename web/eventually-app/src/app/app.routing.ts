
import { RouterModule, Routes } from '@angular/router';
import { EventGalleryComponent } from './components/event-gallery/event-gallery.component';

export const appRoutes: Routes = [
    { path: 'events', component: EventGalleryComponent },
  ];
