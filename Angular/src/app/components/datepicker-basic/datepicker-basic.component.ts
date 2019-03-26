import { Component, Output, EventEmitter, Input } from '@angular/core';
import { NgbCalendar, NgbDateStruct, NgbDate, NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-datepicker-basic',
  templateUrl: './datepicker-basic.component.html',
})
export class DatepickerBaseComponent {

  @Output()
  selectedDate = new EventEmitter<NgbDate>();

  model: NgbDateStruct;

  _date: NgbDate;

  constructor(private calendar: NgbCalendar, config: NgbDatepickerConfig) {
    config.minDate = { year: 1900, month: 1, day: 1 };
    config.maxDate = {
      year: calendar.getToday().year - 18,
      month: calendar.getToday().month,
      day: calendar.getToday().day
    };
    config.outsideDays = 'hidden';
    config.firstDayOfWeek = 7;
  }

  selectToday() {
    this.model = this.calendar.getToday();
  }

  onDateSelection(date: NgbDate) {
    this._date = date;
    this.selectedDate.emit(this._date);
  }
}
