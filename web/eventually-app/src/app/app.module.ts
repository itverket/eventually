import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { appRoutes } from './app.routing';
import { NavigationButtonComponent } from './layout/buttons/navigation-button/navigation-button.component';
import { EventService } from './service/event.service';
import { EventCardComponent } from './components/event-card/event-card.component';
import { EventGalleryComponent } from './components/event-gallery/event-gallery.component';
import { MainComponent } from './components/main/main.component';
import { NewEventButtonComponent } from './component/new-event-button/new-event-button.component';
import { SidebarMenuComponent } from './component/sidebar-menu/sidebar-menu.component';
import { FormInputComponent } from './components/form-input/form-input.component';
import { EventFormComponent } from './components/event-form/event-form.component';
import { SaveButtonComponent } from './components/save-button/save-button.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationButtonComponent,
    EventGalleryComponent,
    EventCardComponent,
    MainComponent,
    NewEventButtonComponent,
    SidebarMenuComponent,
    FormInputComponent,
    EventFormComponent,
    SaveButtonComponent,
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
    ),
    BrowserModule,
  ],
  providers: [
    EventService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


