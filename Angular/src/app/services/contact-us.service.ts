import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactUsMessageModel } from '../models/contact-us-message';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContactUsService {


  public constructor(private http: HttpClient) { }

  public addContactUsMessage(contactUsMessageModel: ContactUsMessageModel): Observable<ContactUsMessageModel> {
    return this.http.post<ContactUsMessageModel>(`${environment.apiUrl}/contact-us`, contactUsMessageModel);
  }
}
