import { Component, OnInit } from '@angular/core';
import { AdminUserService } from '../../services/admin-user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
})
export class UserListComponent implements OnInit {

  public data: User[];
  public userName: string;
  public getData: User[];
  constructor(private adminUserService: AdminUserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.userName = params['userName'];
      this.searchUser(this.userName);
    });

  }


  // Ability to add search function by username
  async searchUser(userName: string) {
    await this.adminUserService.getAllUsers()
      .then(users => {
        this.getData = users;
      });
    if (userName === undefined) {
      this.data = this.getData;
    }
  }
}
