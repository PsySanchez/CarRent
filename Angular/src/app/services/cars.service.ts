import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CarsService {
    constructor(private http: HttpClient) { }

    getAllCars() {
        return this.http.get<any>(`${environment.apiUrl}/cars`)
            .pipe(map(cars => {
                return cars;
            }));
    }

    getOneCars(id: number) {
        return this.http.get<any>(`${environment.apiUrl}/cars/${id}`)
        .pipe(map(car => {
             return car;
         }));
    }

    getAllModels(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/model`)
            .toPromise()
            .then(result => {
                return result;
            });
    }

    getAllManufacturers(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/manufacturer`)
            .toPromise()
            .then(result => {
                return result;
            });
    }
}
