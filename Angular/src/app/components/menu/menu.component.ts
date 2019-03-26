import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services';

import { Router, ActivatedRoute } from '@angular/router';


@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    public logIn = true;
    public IsUserLoggedIn: boolean;
    public logOut = false;
    public orders = false;
    public register = true;
    public admin = false;
    public currentUser: string[];
    public returnUrl: string;

    constructor(public authenticationService: AuthenticationService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.authenticationService.IsUserLoggedIn.subscribe(value => {
            this.IsUserLoggedIn = value;
            if (this.IsUserLoggedIn) {
                this.logOut = true;
                this.logIn = false;
                this.orders = true;
                this.register = false;
                // Check if user is admin, check by name, since only one admin)
                this.currentUser = localStorage.getItem('currentUser').substring(1, 40).split(',');
                if (this.currentUser[0] === '"firstName":"Alex"' && this.currentUser[1] === '"lastName":"Voronin"') {
                    this.admin = true;
                }
            } else {
                this.logIn = true;
                this.logOut = false;
                this.orders = false;
                this.admin = false;
                this.register = true;
            }
        });
        this.route.queryParams.subscribe(params => {
            this.returnUrl = params['returnUrl'];
        });
    }
}
