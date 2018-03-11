import { Component, OnInit } from '@angular/core';
import { menuItems } from './models/menu-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Eventually';
  menuItems: MenuItem[] = menuItems;
}
