import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent implements OnInit {

  @Input() type = 'text';
  @Input() value;
  @Input() label = '';

  @Output() valueChange = new EventEmitter<Object>();

  constructor() { }

  ngOnInit() {
  }

  onBlur(value: Object) {
    this.valueChange.emit(value);
  }

  public isTextArea(): boolean {
    return this.type === 'textarea';
  }


}
