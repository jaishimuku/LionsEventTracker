import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Token } from '@angular/compiler';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isAdmin = false;
  constructor( private router: Router) {}

   ngOnInit() {
     const user = localStorage.getItem('user');
     if (!user) {
      return this.router.navigate(['/login']);
     }
     console.log('This is user');
     /*  console.log(JSON.parse(user)); */
       this.isAdmin = JSON.parse(user).isAdmin;

  }

  logout(e) {
    e.preventDefault();

    console.log('logging user out');
    localStorage.removeItem('user');
    return this.router.navigate(['/login']);

  }

}
