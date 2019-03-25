import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';
import { CarsComponent } from './components/cars/cars.component';
import { OrderComponent } from './components/order/order.component';
import { UserOrdersComponent } from './components/user-orders/user-orders.component';
import { Page404Component } from './components/page404/page404.component';
import { AuthGuard } from './components/guards';


const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'contacts', component: ContactsComponent },
    { path: 'about', component: AboutComponent},
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'logout', component: LogoutComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'order', component: OrderComponent },
    { path: 'userOrders', component: UserOrdersComponent },
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'admin', loadChildren: './admin/admin.module#AdminModule' },
    // { path: "", redirectTo: "home", pathMatch: "full" },
    { path: '**', component: Page404Component },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {

  }
