import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { appRoutes } from './app.routing';
import { NavigationButtonComponent } from './layout/buttons/navigation-button/navigation-button.component';
import { EventService } from './service/event.service';
import { ApiClient } from './service/api-client';
import { EventCardComponent } from './components/event-card/event-card.component';
import { EventGalleryComponent } from './components/event-gallery/event-gallery.component';
import { MainComponent } from './components/main/main.component';
import { NewEventButtonComponent } from './layout/buttons/new-event-button/new-event-button.component';
import { SidebarMenuComponent } from './layout/sidebar-menu/sidebar-menu.component';
import { FormInputComponent } from './components/form-input/form-input.component';
import { EventFormComponent } from './components/event-form/event-form.component';
import { SaveButtonComponent } from './components/save-button/save-button.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardHeaderComponent } from './components/dashboard-header/dashboard-header.component';
import { FilterPipe } from './pipes/filter.pipe';
import { FormsModule } from '@angular/forms';

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
    DashboardComponent,
    DashboardHeaderComponent,
    FilterPipe,
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
    ),
    BrowserModule,
     HttpClientModule,
     FormsModule
     
  ],
  providers: [
    EventService,
    ApiClient

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


