import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { ServUserService } from '../Services/serv-user.service';
import { ServSubscriptionService } from '../Services/serv-subscription.service';

@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.css']
})
export class UserpageComponent implements OnInit {
  id: Object;
  user: Object;
  eventList: Object;

  constructor(private subserv: ServSubscriptionService, private userServ: ServUserService, private _route: ActivatedRoute) { 
    this._route.params.subscribe(params => this.id = params.id);

    this._route.url.subscribe(url => {
      this.userServ.getUser(this.id).subscribe(data => this.user = data);
      this.subserv.getListOfEventsByUser(+this.id).subscribe(subserv => this.eventList = subserv);
    });
  }
  
  ngOnInit() {
  }

  removeSubscription(id: number) {
    this.subserv.removeSubscription(id).subscribe(data => this.id = data);
  }

  removeEvent() {

  }

}
