import { Component, OnInit } from '@angular/core';
import { CompanyFleet } from '../../models/companyFleet.model';
import { ManagmentService } from '../../services/managment.service';
import { imagesFolder } from 'src/environments/environment';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/services';
import { Model } from '../../models/model.model';


@Component({
  selector: 'app-company-fleet-table',
  templateUrl: './company-fleet-table.component.html',
  styleUrls: ['./company-fleet-table.component.css']
})
export class CompanyFleetTableComponent implements OnInit {

  public imagesFolder: string;
  public data: CompanyFleet[];
  public car: CompanyFleet = new CompanyFleet;
  public selectCar: CompanyFleet;
  public models: Model[];

  public model: string;
  public carNumber: string;

  constructor(
    private managmentService: ManagmentService,
    private alertService: AlertService) { }

  ngOnInit() {
    this.imagesFolder = imagesFolder;
    this.managmentService.getAllCompanyFleets()
      .then(model => {
        this.data = model;
      });

    this.managmentService.getAllModels()
      .then(model => {
        this.models = model;
      });
  }

  // Update company fleet by id:
  async update(car: CompanyFleet) {
    const carNum = prompt('Car number: ', car.carNumber);
    if (carNum == null || carNum === '') {
      alert('Nothing entered!');
    } else if (window.confirm('Do you really want to update?')) {
      car.carNumber = carNum;
      await this.managmentService.updateCompanyFLeet(car)
        .then(() => {
          alert('Successfully updated!');
        });
    }
  }

  // Remove company fleet:
  async remove(id: any) {
    if (window.confirm('Do you really want to remove?')) {
      await this.managmentService.removeCompanyFleet(id)
        .then(() => {
          alert('Successfully deleted!');
        });
        this.managmentService.getAllCompanyFleets()
        .then(model => {
          this.data = model;
        });
    }
  }

  // Add new company fleet:
  add() {
    const id = this.models.filter(item => {
      return item.model.includes(this.model);
    });

    this.car.carNumber = this.carNumber;
    this.car.modelId = id[0].id;
    this.managmentService.addNewCompanyFleet(this.car).pipe(first())
      .subscribe(() => {
          this.alertService.success('Add new car successful', true);
          setTimeout(function () { window.location.reload(); }, 3000);
        },
        error => {
          this.alertService.error(error);
        });
  }

  // Clear input field:
  clear() {
    this.model = null;
    this.carNumber = '';
  }
}
