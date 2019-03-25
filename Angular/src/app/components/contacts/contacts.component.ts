import { Component } from '@angular/core';
import { ContactUsMessageModel } from '../../models/contact-us-message';
import { ContactUsService } from '../../services/contact-us.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-contacts',
    templateUrl: './contacts.component.html',
    styleUrls: ['./contacts.component.css']
})
export class ContactsComponent {
    public contactUsMessageModel = new ContactUsMessageModel();

    constructor(private contactUsService: ContactUsService, private router: Router) { }

    public send(): void {
        const ob = this.contactUsService.addContactUsMessage(this.contactUsMessageModel);
        ob.subscribe(() => {
            alert('Your message has been successfully saved.');
            this.router.navigate(['/home']);
        }, response => {
            alert('Error: ' + response.error);
            console.log(response.error);
        });
    }
}
