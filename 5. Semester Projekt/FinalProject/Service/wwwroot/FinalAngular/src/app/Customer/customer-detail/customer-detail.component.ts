import { Component, OnInit } from '@angular/core';
import { Notification } from '../../entities/notification'
import { ApiService } from '../../api.service';
import { ServCustomerService } from '../../Services/serv-customer.service';
import { ServSubscriptionService } from '../../Services/serv-subscription.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  id: Object;
  customer: Object;
  event: Object;
  userId: number;
  eventForm: FormGroup;
  cusId: number;

  notification: boolean = false;

  constructor(private data: ApiService, private dataSub: ServSubscriptionService, private dataCust: ServCustomerService, private _route: ActivatedRoute, private formBuilder: FormBuilder) {
    this._route.params.subscribe(params => this.id = params.id);

    this._route.url.subscribe(url => {
      this.dataCust.getCustomerById(this.id).subscribe(data => this.customer = data);
    });
  }

  ngOnInit() {
    this.userId = +localStorage.getItem('tokenId');
    this.cusId = +localStorage.getItem('tokenCusId');
    this.eventForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  getEventById(id: number) {
  }

  createSubscription(customerID: number){
    this.dataSub.createSubscription(this.userId, customerID, this.notification);
  }

  get f() { return this.eventForm.controls; }

  insertEvent() {
    var date = new Date("2016-01-17T08:44:29+0100");
    this.data.insertEvent(this.f.title.value, this.f.description.value, date, +this.id);

    //Creates a array of notifications, for inserting into the database.
    let list: Array<any> = [];
    for (let item of this.customer['subsId']) {
      var temp = new Notification(item, this.customer['name'] + ": "+ this.f.title.value);
      list.push(temp);
    }
    this.data.InsertNotification(list);
  }
  
  insertNews() {
    var date = new Date("2016-01-17T08:44:29+0100");
    this.data.insertNews("nyhed test", "Dette er en nyhed", date, +this.id);
  }

  InsertEventUser(eventId: number) {
    this.data.insertEventUser(eventId, this.userId);
  }
}
