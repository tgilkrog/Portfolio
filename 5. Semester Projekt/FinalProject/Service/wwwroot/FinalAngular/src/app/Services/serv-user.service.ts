import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from '../entities/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServUserService {

  constructor(private http: HttpClient) { }
  url: String = "http://localhost:51250/api/";

  createUser(username: string, password: string, email: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urluncoded'
      })
    };
    let data = new User(username, password, email);
    this.http.post(this.url + 'user', data).subscribe();
  }

  getUser(id) {
    return this.http.get(this.url + "user/" + id);
  }

  getUserByNameAndPass(username: string, password: string): Observable<any> {
    return this.http.get(this.url + "user/" + username + "/" + password);
  }
}
