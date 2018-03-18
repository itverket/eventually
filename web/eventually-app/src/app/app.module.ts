import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { appRoutes } from './app.routing';
import { EventService } from './services/event.service';
import { ApiClient } from './services/api-client';
import { CardComponent } from './components/layout/card/card.component';
import { EventGalleryComponent } from './components/event/event-gallery/event-gallery.component';
import { NewEventButtonComponent } from './components/layout/buttons/new-event-button/new-event-button.component';
import { SidebarMenuComponent } from './components/layout/sidebar-menu/sidebar-menu.component';
import { FormInputComponent } from './components/layout/form-input/form-input.component';
import { EventFormComponent } from './components/event/event-form/event-form.component';
import { SaveButtonComponent } from './components/layout/buttons/save-button/save-button.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardHeaderComponent } from './components/dashboard-header/dashboard-header.component';
import { FilterPipe } from './pipes/filter.pipe';
import { FormsModule } from '@angular/forms';
import { LoadingIndicatorComponent } from './components/layout/loading-indicator/loading-indicator.component';
import { TimeLabelComponent } from './components/layout/time-label/time-label.component';
import { CardLabelComponent } from './components/layout/card-label/card-label.component';



@NgModule({
  declarations: [
    AppComponent,
    EventGalleryComponent,
    CardComponent,
    NewEventButtonComponent,
    SidebarMenuComponent,
    FormInputComponent,
    EventFormComponent,
    SaveButtonComponent,
    DashboardComponent,
    DashboardHeaderComponent,
    FilterPipe,
    LoadingIndicatorComponent,
    TimeLabelComponent,
    CardLabelComponent,
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


