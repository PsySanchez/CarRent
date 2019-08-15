import { Component, OnInit, Input, ɵConsole } from '@angular/core';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';
import { Car } from '../../models/car';

import { imagesFolder } from '../../../environments/environment.prod';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-date';


@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
    styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

    public returnUrl: string;
    public allCars: Car[];
    public imagesFolder: string;
    public showTable = false;
    public id: number;
    public _fromDate: NgbDate;
    public _toDate: NgbDate;
    public manufacturer: string;
    public model: string;

    public isDisabledModels = true;

    public defaultItemManufacturers: {
        manufacturer: string,
        manufacturerId: number} = {
            manufacturer: 'Select category',
            manufacturerId: null
        };

    public defaultItemModels: { model: string, modelId: number } = { model: 'Select product', modelId: null };

    public dataManufacturer: Array<{ manufacturer: string, manufacturerId: number }> = [];

    public dataModel: Array<{ model: string, modelId: number, manufacturerId: number }> = [];
    public dataResultCars: Array<{ model: string, modelId: number, manufacturerId: number }>;

    public selectedManufacturer: { manufacturer: string, manufacturerId: number };
    public selectedModel: { model: string, modelId: number };

    constructor(
        private carsService: CarsService,
        private router: Router) { }

    ngOnInit() {
        this.imagesFolder = imagesFolder;
        this.carsService.getAllCars().subscribe(cars => {
            this.allCars = cars;
            this.dataManufacturer = cars;
            this.dataModel = cars;
            console.log(this.dataManufacturer);
        });
    }

    handleCategoryChange(value) {
        this.selectedManufacturer = value;
        this.manufacturer = this.selectedManufacturer.manufacturer;
        this.selectedModel = undefined;
        this.model = null;

        if (value.manufacturerId === this.defaultItemManufacturers.manufacturerId) {
            this.isDisabledModels = true;
            this.dataResultCars = [];
        } else {
            this.isDisabledModels = false;
            this.dataResultCars = this.dataModel.filter((s) => s.manufacturerId === value.manufacturerId);
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
    public SetDateToNull() {
        this._fromDate = null;
        this._toDate = null;

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
