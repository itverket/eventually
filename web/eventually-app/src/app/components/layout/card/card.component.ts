import { Component, OnInit, Input } from '@angular/core';
import { IEvent } from '../../../interfaces/IEvent';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() event: IEvent;


  constructor() { }

  ngOnInit() {
  }

  getDateFormat() {
    return this.sameDay(this.event.starts, this.event.ends) ? 'HH:mm' : 'HH:mm, d.MM.y';
  }

  private sameDay(d1: Date, d2: Date): boolean {

    if (!d1 || !d2) { return false }
    return d1.getFullYear() === d2.getFullYear() &&
      d1.getMonth() === d2.getMonth() &&
      d1.getDate() === d2.getDate();
  }

}
