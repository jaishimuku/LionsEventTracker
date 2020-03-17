import { Component, OnInit } from '@angular/core';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../share/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  events: Event[];
  users: User[];
  subscribed = false;
  isAdmin = false;
  searchTerm: string;
  userName: string;
  constructor(private http: HttpClient, private router: Router) {}
   ngOnInit() {
       this.http.get<any>(`${SERVER_ROOT}/api/Events/getEvents`).subscribe(
      response => {
        this.events = response;
        console.log(this.events);
      }
    );
  
       const user = localStorage.getItem('user');
       this.userName = JSON.parse(user).userName;
       if (!user) {
        return this.router.navigate(['/login']);
       }
       console.log('This is user');
         this.isAdmin = JSON.parse(user).isAdmin;
    }
  
    DeleteEvent(event){
      confirm("Are you sure to Delete this Event ?");
      this.http.delete<any>(`${SERVER_ROOT}/api/Events/Remove`+'/'+ event.id).subscribe(
        response => {
          let index =this.events.indexOf(event);
          this.events.slice(index, 1);
          window.location.reload();
        }
      );
    }


    UpdateEvent(event){
      this.router.navigate(['/updateevent/'], {queryParams: {eventId: event.id}});
    }


  subscribe(event) {
    const user = localStorage.getItem('user');
    console.log(event.subscribed);
    if(!event.subscribed){
      this.http.get<any>(`${SERVER_ROOT}/api/Events/Subscribe`+'?eventId='+ event.id + '&userId=' + JSON.parse(user).id).subscribe(
        response => {
          
        }
      );   
    }
    event.subscribed = !event.subscribed;
        
  }   
}
