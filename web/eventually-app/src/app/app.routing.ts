
import { RouterModule, Routes } from '@angular/router';
import { EventGalleryComponent } from './components/event-gallery/event-gallery.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';


export const appRoutes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'events', component: EventGalleryComponent },
  ];
