import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order';
import { imagesFolder } from '../../../environments/environment.prod';
import { OrderService } from 'src/app/services/order.service';

@Component({
    selector: 'app-user-orders',
    templateUrl: './user-orders.component.html',
    styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit {

    public imagesFolder: string;
    public userOrders: Order[];



    constructor(private orderService: OrderService) { }


    async ngOnInit() {
        this.imagesFolder = imagesFolder;
        await this.orderService.getUserOrders()
            .then(orders => {
                this.userOrders = orders;
            });
    }
}
