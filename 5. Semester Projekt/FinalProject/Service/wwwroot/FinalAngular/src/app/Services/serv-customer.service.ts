import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServCustomerService {

  constructor(private http: HttpClient) { }
  url: String = "http://localhost:51250/api/";

  getAllCustomers() {
    return this.http.get(this.url + "customer/");
  }
  getCustomerById(id) {
    return this.http.get(this.url + "customer/" + id);
  }
  getCustomerByName(name: string) {
    if (name !== "")
      return this.http.get(this.url + "customer/search/" + name);
    else
      return this.http.get(this.url + "customer/search/zsweoyurfgjth");
  }
  getCustomerByPostalName(postal: number, city: string) {
    return this.http.get(this.url + "customer/get/" + postal + "/" + city);
  }
}
