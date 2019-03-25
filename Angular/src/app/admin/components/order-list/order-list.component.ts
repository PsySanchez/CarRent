import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order';

import { ActivatedRoute } from '@angular/router';
import { AdminOrderService } from '../../services/admin-order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  public data: Order[];
  public userName: string;
  public getData: Order[];
  public imagesFolder: string;
  constructor(private adminUserService: AdminOrderService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.userName = params['userName'];
      this.searchOrder(this.userName);
    });

  }

  // Ability to add search function by username
  async searchOrder(userName: string) {
    await this.adminUserService.getAllOrders()
      .then(orders => {
        this.getData = orders;
      });
    if (userName === undefined) {
      this.data = this.getData;
    }
  }
}
