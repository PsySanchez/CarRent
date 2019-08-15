import { Component, OnInit } from '@angular/core';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';
import { Car } from '../../models/car';

import { imagesFolder } from '../../../environments/environment.prod';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';
import { CarModel } from 'src/app/models/carModel';
import { CarManufacturer } from 'src/app/models/carManufacturer';


@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
})
export class CarsComponent implements OnInit {

    public allCars: Car[];
    public imagesFolder: string;
    public _fromDate: NgbDate;
    public _toDate: NgbDate;
    public manufacturer: string;
    public model: string;

    public isDisabledModels = true;

    public defaultItemManufacturers: { manufacturer: string, id: number } = { manufacturer: 'Select category', id: null };

    public defaultItemModels: { model: string, id: number } = { model: 'Select product', id: null };
    public dataManufacturer: CarManufacturer;

    public dataModel: CarModel[];
    public dataResultCars: CarModel[];

    public selectedManufacturer: CarManufacturer;
    public selectedModel: { model: string, id: number };

    constructor(
        private carsService: CarsService,
        private router: Router) { }

    ngOnInit() {
        this.imagesFolder = imagesFolder;
        this.carsService.getAllCars().subscribe(cars => {
            this.allCars = cars;
        });

        this.carsService.getAllModels()
            .then(model => {
                this.dataModel = model;
            });

        this.carsService.getAllManufacturers()
            .then(manf => {
                this.dataManufacturer = manf;
            });
    }


    handleCategoryChange(value) {
        this.selectedManufacturer = value;
        this.manufacturer = this.selectedManufacturer.manufacturer;
        this.selectedModel = undefined;
        this.model = null;

        if (value.id === this.defaultItemManufacturers.id) {
            this.isDisabledModels = true;
            this.dataResultCars = [];
        } else {
            this.isDisabledModels = false;
            this.dataResultCars = this.dataModel.filter((s) => s.manufacturerId === value.id);
        }
    }

    handleProductChange(value) {
        this.selectedModel = value;
        this.model = this.selectedModel.model;
    }

    public onFromDateSelected(fromDate: NgbDate) {
        this._fromDate = fromDate;
    }
    public onToDateSelected(toDate: NgbDate) {
        this._toDate = toDate;
    }

    public fromToDateSelected(): boolean {
        if (this._fromDate && this._toDate) {
            return true;
        }
        return false;
    }

    goToOrders(id: number) {
        this.router.navigate(['/order'], {
            queryParams: {
                carId: id,
                fromDate: JSON.stringify(this._fromDate),
                toDate: JSON.stringify(this._toDate)
            }
        });
    }
}
