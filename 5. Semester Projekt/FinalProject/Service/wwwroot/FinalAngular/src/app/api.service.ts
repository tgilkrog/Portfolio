import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from './entities/user';
import { Subscription } from './entities/subscription';
import { Form } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Options } from 'selenium-webdriver/ie';
import { jsonpCallbackContext } from '@angular/common/http/src/module';
import { Event } from './entities/event';
import { News } from './entities/news';
import { EventUser } from './entities/event-user';
import { Notification } from './entities/notification';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  url: String = "http://localhost:51250/api/";

  //Method for logging out, and removing some information which is stored
  logout(): void {
    localStorage.setItem('isLoggedIn', "false");
    localStorage.removeItem('tokenId');
    localStorage.removeItem('tokenName');
    localStorage.removeItem('tokenCusId');
  }

  insertEvent(title: string, description: string, date: Date, cusId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    let data = new Event(title, description, date, cusId);
    this.http.post(this.url + 'customer/postEvent', data).subscribe();
  }

  InsertNotification(notification) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    this.http.post(this.url + 'customer/postNotifications', notification).subscribe();
  }

  insertNews(title: string, description: string, date: Date, cusId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    let data = new News(title, description, date, cusId);
    this.http.post(this.url + 'customer/postNews', data).subscribe();
  }

  insertEventUser(eventId: number, userId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    let data = new EventUser(eventId, userId);
    this.http.post(this.url + 'subscription/insertEventUser', data).subscribe();
  }
}
