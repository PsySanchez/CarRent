import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { CompanyFleet } from '../models/companyFleet.model';


// Managment service only works with administrative requests for the api controller,
// to add, update and delete data on it.


@Injectable({ providedIn: 'root' })
export class ManagmentService {

    constructor(private http: HttpClient) {}


    // Get all models from api:
    getAllModels(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/model`)
            .toPromise()
            .then(result => {
                return result;
            });
    }
    // Get model by id from api:
    getById(id: number) {
        return this.http.get(`/users/` + id);
    }

    // Get all company fleet from api:
    getAllCompanyFleets(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/managment/companyFleet`)
            .toPromise()
            .then(result => {
                return result;
            });
    }

    // Add new company fleet from api:
    addNewCompanyFleet(companyFleet: CompanyFleet) {
        return this.http.post(`${environment.apiUrl}/managment/companyFleet`, companyFleet);
    }

    // Remove company fleet by id from api:
    removeCompanyFleet(id: number): Promise<any> {
        return this.http.delete(`${environment.apiUrl}/managment/companyFleet/ ${id}`)
            .toPromise()
            .then(result => {
                return result;
            });
    }
    // Update company fleet in api:
    updateCompanyFLeet(companyFleet: CompanyFleet): Promise<any> {
        return this.http.patch(`${environment.apiUrl}/managment/companyFleet/${companyFleet.id}`
            , companyFleet)
            .toPromise()
            .then(result => {
                return result;
            },
                reject => {
                    console.log(reject);
                });
    }
}
