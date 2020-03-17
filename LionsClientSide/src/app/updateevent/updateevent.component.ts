import { Component, OnInit } from '@angular/core';
import { SERVER_ROOT } from '../config';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-updateevent',
  templateUrl: './updateevent.component.html',
  styleUrls: ['./updateevent.component.css']
})
export class UpdateeventComponent implements OnInit {

  event: any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { 
    this.event = {};
  }


  updateEvent(e, event) {
    e.preventDefault();
    if (!event.valid) {
      return;
    }
    this.http.post<any>(`${SERVER_ROOT}/api/Events/CreateEvent`, this.event).subscribe(
       response => {
         console.log(response);
         this.router.navigate(['/home']);
       }
     );
}


  ngOnInit() {
    var eventId = this.route.queryParams.subscribe((params)=> {
      var eventId = params['eventId'];
      this.http.get<any>(`${SERVER_ROOT}/api/Events/GetEventsById`+ '/' + eventId).subscribe(
        response => {
          var event = response;
          console.log('response', event);
          event.time = event.time.trim();
          this.event = event;
       }
     );
    });
  }

}
