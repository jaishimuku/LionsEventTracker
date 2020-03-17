import { Event } from '../shared/event';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { SERVER_ROOT } from '../config';

@Component({
  selector: 'app-eventcreate',
  templateUrl: './eventcreate.component.html',
  styleUrls: ['./eventcreate.component.css']
})
export class EventcreateComponent  {

  constructor( private router: Router, private http: HttpClient) {
        }
        event: Event = new Event;

        createEvent(e, events) {
          e.preventDefault();
          if (!events.valid) {
            return;
          }
          console.log(this.event);
          const user = localStorage.getItem('user');
            if (!user) {
             return this.router.navigate(['/login']);
            }

          this.http.post<any>(`${SERVER_ROOT}/api/Events/CreateEvent`, this.event).subscribe(
             response => {
               console.log(response);
               this.router.navigate(['/home']);
             }
           );
}

  logout(e) {
  e.preventDefault();

  console.log('logging user out');
  localStorage.removeItem('user');
  return this.router.navigate(['/login']);

}

 }
 export class AppComponent{
  tittle='app';
  organizations =['MISA', 'SGA', 'NSAS'];
}