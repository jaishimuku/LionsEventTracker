import { Component, OnInit } from '@angular/core';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../share/user.model';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private router: Router, private http: HttpClient) {}

  user: User;

  ngOnInit() {
    const user = JSON.parse(localStorage.getItem('user'));
    this.http.get<any>(`${SERVER_ROOT}/api/User/GetUserById/` + user.id).subscribe(
    response => {
      console.log(response, 'user resposne');
      this.user = response;
      console.log(this.user);
    }
 );
}

}
