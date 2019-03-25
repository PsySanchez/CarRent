import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap' ;
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import {DataTableModule} from 'angular-6-datatable';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from '../app/components/home/home.component';
import { MenuComponent } from '../app/components/menu/menu.component';
import { HeaderComponent } from '../app/components/header/header.component';
import { LayoutComponent } from '../app/components/layout/layout.component';
import { Page404Component } from '../app/components/page404/page404.component';
import { ContactsComponent } from '../app/components/contacts/contacts.component';
import { LoginComponent } from '../app/components/login/login.component';
import { AlertService, AuthenticationService, UserService } from './services';
import { RegisterComponent } from '../app/components/register/register.component';
import { AlertComponent } from '../app/components/directives';
import { AuthGuard } from '../app/components/guards';
import { CarsService } from './services/cars.service';
import { CarsComponent } from './components/cars/cars.component';
import { TokenInterceptor, ErrorInterceptor } from './components/helpers';
import { CarouselConfigComponent } from './components/home/carousel-config';
import { AboutComponent } from './components/about/about.component';
import { NgbdDatepickerRangeComponent } from './components/datepicker-range/datepicker-range.component';
import { LogoutComponent } from './components/logout/logout.component';
import { ModelFilterPipe } from './pipes/modelFilter.pipe';
import { ManufacturerFilterPipe } from './pipes/manufacturerFilter.pipe';
import { OrderComponent } from './components/order/order.component';
import { DatepickerBaseComponent } from './components/datepicker-basic/datepicker-basic.component';
import { UserOrdersComponent } from './components/user-orders/user-orders.component';


@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    MenuComponent,
    HomeComponent,
    Page404Component,
    ContactsComponent,
    LoginComponent,
    RegisterComponent,
    AlertComponent,
    CarsComponent,
    CarouselConfigComponent,
    AboutComponent,
    NgbdDatepickerRangeComponent,
    LogoutComponent,
    ModelFilterPipe,
    ManufacturerFilterPipe,
    OrderComponent,
    DatepickerBaseComponent,
    UserOrdersComponent,

  ],
  imports: [
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
    DropDownsModule,
    DataTableModule,

  ],
  providers: [
     { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthGuard,
    AlertService,
    AuthenticationService,
    UserService,
    CarsService,
  ],
  bootstrap: [LayoutComponent]
})
export class AppModule { }
