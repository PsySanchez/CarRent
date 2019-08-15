import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService, UserService } from '../../services';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;
    loading = false;
    submitted = false;
    selectedDate: NgbDate;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private userService: UserService,
        private alertService: AlertService) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            email: ['', Validators.required],
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]],
            telephone: ['', [Validators.required, Validators.minLength(6)]],
            dateOfBirth: ['', Validators.required]
        });
    }

    public onDateSelected(date: NgbDate) {
        this.selectedDate = date;
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }
    onSubmit() {
        this.submitted = true;

        console.log(this.registerForm.value);
        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }
        // Date of birth:
        const date = new Date(Date.UTC(this.selectedDate.year, this.selectedDate.month - 1, this.selectedDate.day));
        this.registerForm.controls['dateOfBirth'].setValue(date);
        this.loading = true;
        this.userService.register(this.registerForm.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Registration successful', true);
                this.router.navigate(['/login']);
            },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}
