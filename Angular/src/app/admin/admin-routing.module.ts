import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './components/user-list/user-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { HomeComponent } from './components/home/home.component';
import { ManagmentComponent } from './components/managment/managment.component';



const routes: Routes = [
  { path: 'orders', component: OrderListComponent },
  { path: 'users', component: UserListComponent },
  { path: 'managment', component: ManagmentComponent },

  { path: '', component: HomeComponent, }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
