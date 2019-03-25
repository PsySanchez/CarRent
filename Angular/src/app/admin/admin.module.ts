import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTableModule } from 'angular-6-datatable';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { UserListComponent } from './components/user-list/user-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { AdminRoutingModule } from './admin-routing.module';
import { HomeComponent } from './components/home/home.component';
import { ManagmentComponent } from './components/managment/managment.component';
import { AdminMenuComponent } from './components/admin-menu/admin-menu.component';
import { CompanyFleetTableComponent } from './components/company-fleet-table/company-fleet-table.component';




@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    DataTableModule,
    MDBBootstrapModule,
    FormsModule,
    DropDownsModule
  ],
  declarations: [
    UserListComponent,
    OrderListComponent,
    HomeComponent,
    ManagmentComponent,
    AdminMenuComponent,
    CompanyFleetTableComponent
  ],
  exports: [UserListComponent, OrderListComponent],
})
export class AdminModule { }
