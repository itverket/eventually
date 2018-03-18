import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-time-label',
  templateUrl: './time-label.component.html',
  styleUrls: ['./time-label.component.scss']
})
export class TimeLabelComponent implements OnInit {


@Input() startTime: Date;
@Input() endTime: Date;

  constructor() { }

  ngOnInit() {
  }

}
