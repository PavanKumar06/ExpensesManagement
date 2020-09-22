import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  // tslint:disable-next-line: typedef
  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in Successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      if (this.authService.decodedToken?.role !== 'manager')
      {
        this.router.navigate(['/employee']);
      }
      else
      {
        this.router.navigate(['/manager']);
      }
    });
  }

  // tslint:disable-next-line: typedef
  loggedIn() {
    return this.authService.loggedIn();
  }

  // tslint:disable-next-line: typedef
  logout() {
    localStorage.removeItem('token');
    this.authService.decodedToken = null;
    this.alertify.message('Logged Out');
    this.router.navigate(['/home']);
  }

  // tslint:disable-next-line: typedef
  denied() {
    return (this.authService.decodedToken?.role === 'manager');
  }

}
