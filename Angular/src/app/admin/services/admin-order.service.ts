import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

import { Order } from '../../models/order';


@Injectable({ providedIn: 'root' })
export class AdminOrderService {
    constructor(private http: HttpClient) { }

      getAllOrders(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/allOrders`)
        .toPromise()
        .then(result => {
            return result;
        });
    }
}

