import { HttpClient } from '@angular/common/http';
import { User } from './../share/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SERVER_ROOT } from '../config';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private router: Router, private http: HttpClient) {
    this.user.UserName = '';
    this.user.Password = '';
   }

  user: User = new User;
  isError = false;
  errorMessage: string;
  IsVerified = false;

  logInUser(e, form) {
      e.preventDefault();
      if (!form.valid) {
        return;
      }
      console.log(this.user);

      this.http.post<any>(`${SERVER_ROOT}/api/User/LogIn`, this.user).subscribe(
         user => {
          console.log('got data from server', user);
          localStorage.setItem('user', JSON.stringify(user));
          this.router.navigate(['/home']);
         },
         error => {
           this.isError = true;
           this.errorMessage = error.error;
           if (error.error !== 'Unverified') {
             this.errorMessage = 'Invalid';
           }
        }
      );
        }
    }
