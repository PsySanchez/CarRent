import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

import { User } from '../models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    // getById(id: number) {
    //     return this.http.get(`/users/` + id);
    // }

    register(user: User) {
        return this.http.post(`${environment.apiUrl}/register`, user);
    }

    // update(user: User) {
    //     return this.http.put(`/users/` + user.id, user);
    // }
}
