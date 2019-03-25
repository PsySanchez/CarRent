import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

import { Order } from '../models/order';


@Injectable({ providedIn: 'root' })
export class OrderService {
    constructor(private http: HttpClient) { }

    addNewOrder(order: Order) {
        return this.http.post(`${environment.apiUrl}/order`, order);
    }

    getUserOrders(): Promise<any> {
        return this.http.get<any>(`${environment.apiUrl}/userOrders`)
        .toPromise()
        .then(data => {
           return data;
        });
    }
}
