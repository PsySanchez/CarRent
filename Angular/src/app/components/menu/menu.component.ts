import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services';


@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    public logIn = true;
    public logOut = false;
    public orders = false;
    public register = true;
    public admin = false;
    public currentUser: string[];

    constructor(public authenticationService: AuthenticationService) { }

    ngOnInit() {
        if (localStorage.getItem('currentUser')) {
            this.logOut = true;
            this.logIn = false;
            this.orders = true;
            this.register = false;
            // Check if user is admin, check by name, since only one admin)
            this.currentUser = localStorage.getItem('currentUser').substring(1, 40).split(',');
            if (this.currentUser[0] === '"firstName":"Alex"' && this.currentUser[1] === '"lastName":"Voronin"') {
                this.admin = true;
            }
        }
    }
}
