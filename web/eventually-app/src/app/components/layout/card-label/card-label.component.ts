import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card-label',
  templateUrl: './card-label.component.html',
  styleUrls: ['./card-label.component.scss']
})
export class CardLabelComponent implements OnInit {

@Input() label: string;
@Input() value: string;


  constructor() { }

  ngOnInit() {
  }

}
