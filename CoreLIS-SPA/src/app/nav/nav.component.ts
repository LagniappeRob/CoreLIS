import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any  = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => { console.log('Login Successful'); },
      error => {console.log(error); }
    );
    console.log('Logged In');
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged Out');
  }
}
