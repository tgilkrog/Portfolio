import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subscription } from '../entities/subscription';

@Injectable({
  providedIn: 'root'
})
export class ServSubscriptionService {

  constructor(private http: HttpClient) { }
  url: String = "http://localhost:51250/api/";

  getListOfEventsByUser(userId: number) {
    return this.http.get(this.url + "subscription/getList/" + userId);
  }

  createSubscription(userID: number, customerID: Object, notification: boolean) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    let data = new Subscription(userID, customerID, notification);
    this.http.post(this.url + 'subscription', data).subscribe();
  }

  removeSubscription(id) {
    return this.http.delete(this.url + "subscription/" + id);
  }
}
