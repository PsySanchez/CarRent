import { Component, Output, EventEmitter } from '@angular/core';
import { NgbCalendar, NgbDateStruct, NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';

@Component({
  selector: 'app-ngbd-datepicker-range',
  templateUrl: './datepicker-range.component.html',
  styles: [`.custom-day {
    text-align: center;
    padding: 0.185rem 0.25rem;
    display: inline-block;
    height: 2rem;
    width: 2rem;
  }
  .custom-day.focused {
    background-color: #e6e6e6;
  }
  .custom-day.range, .custom-day:hover {
    background-color: rgb(2, 117, 216);
    color: white;
  }
  .custom-day.faded {
    background-color: rgba(2, 117, 216, 0.5);
  }`]
})
export class NgbdDatepickerRangeComponent {

  @Output()
  fromDateSelected = new EventEmitter<NgbDate>();
  @Output()
  toDateSelected = new EventEmitter<NgbDate>();

  hoveredDate: NgbDate;
  fromDate: NgbDate;
  toDate: NgbDate;
  model: NgbDateStruct;

  constructor(calendar: NgbCalendar, config: NgbDatepickerConfig) {
    this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 0);
    config.minDate = calendar.getToday();
    config.maxDate = { year: 2020, month: 12, day: 31 };
    config.outsideDays = 'hidden';
    config.firstDayOfWeek = 7;

  }

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
      this.toDateSelected.emit(this.toDate);
    } else {
      this.toDate = null;
      this.fromDate = date;
      this.fromDateSelected.emit(this.fromDate);
    }

  }

  isHovered(date: NgbDate) {
    return this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  }

  isInside(date: NgbDate) {
    return date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return date.equals(this.fromDate) || date.equals(this.toDate) || this.isInside(date) || this.isHovered(date);
  }
}
