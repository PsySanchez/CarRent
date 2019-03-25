import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class AdminUserService {
    constructor(private http: HttpClient) { }

    getAllUsers(): Promise<any> {
        return this.http.get(`${environment.apiUrl}/users`)
        .toPromise()
        .then(result => {
            return result;
        });
    }
}
