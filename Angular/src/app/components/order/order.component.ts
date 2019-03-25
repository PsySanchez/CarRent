import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { imagesFolder } from '../../../environments/environment.prod';
import { CarsService } from '../../services/cars.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/services';


@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',
    styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

    public car: Car;
    public imagesFolder: string;
    public _fromDate: Date;
    public _toDate: Date;
    public order: Order;
    public totalCost;
    public loading = false;
    public carId;


    constructor(private carsService: CarsService,
        private route: ActivatedRoute,
        private orderService: OrderService,
        private alertService: AlertService,
        private router: Router, ) { }


    ngOnInit() {
        this.imagesFolder = imagesFolder;
        this.route.queryParams.subscribe(params => {
            this.carId = params['carId'];
            this._fromDate = JSON.parse(params['fromDate']);
            this._toDate = JSON.parse(params['toDate']);
            this.carsService.getOneCars(this.carId).subscribe(car => {
                this.car = car;
            });
        });
    }

    confirmOrder() {
        this.order = {
            carId: this.carId,
            fromDate: this.convertToDate(this._fromDate),
            toDate: this.convertToDate(this._toDate),
            totalCost: this.getTotalCost(this.convertToDate(this._fromDate), this.convertToDate(this._toDate)),
        };
        this.loading = true;
        console.log(this.order);
        this.orderService.addNewOrder(this.order).pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Order successful', true);
                    this.router.navigate(['/home']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });

    }
    // Calculation total cost from the difference of days:
    getTotalCost(fromDate: Date, toDate: Date) {
        return Math.floor(((toDate.getTime() - fromDate.getTime()) / 1000) / 86400) * this.car.pricePerDay;
    }
    // Function to convert JSON format to date:
    convertToDate(date: any): Date {
        console.log(date);
        return new Date(`${date['year']}-${date['month']}-${date['day']}`);
    }
}
