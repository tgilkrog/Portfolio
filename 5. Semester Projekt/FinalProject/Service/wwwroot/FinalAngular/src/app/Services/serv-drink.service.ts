import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServDrinkService {

  constructor(private http: HttpClient) { }
  url: String = "http://localhost:51250/api/";

  getAllDrinks() {
    return this.http.get(this.url + "drink/");
  }

  getDrinkById(id) {
    return this.http.get(this.url + "drink/" + id);
  }

  getDrinkByName(name) {
    return this.http.get(this.url + "drink/search/" + name);
  }
}
