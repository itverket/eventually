import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation-button',
  templateUrl: './navigation-button.component.html',
  styleUrls: ['./navigation-button.component.scss']
})
export class NavigationButtonComponent {
  @Input() link: string;

  constructor(private router: Router) {
  }

  navigateTo() {
    this.router.navigate([this.link]);
  }
}
