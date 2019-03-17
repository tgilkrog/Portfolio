import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { ServCustomerService } from '../../Services/serv-customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  list: any[];
  filteredList: any[] = [];
  selectedOptions$: number = 0;

  constructor(private data: ApiService, private servCus: ServCustomerService, private _route: ActivatedRoute) {
  }

  ngOnInit() {
  }

  PostalCity(postal, city) {
    //Puts some information into postal and city if they are empty
    //Or else it comes with an error
    if (postal === null)
      postal = 0;
    if (city === null || city === "")
      city = "g";

    //Gets the list by postalcode and/or city name
    this.servCus.getCustomerByPostalName(postal, city)
      .subscribe(data => {
        this.list = Object.entries(data).map(([type, value]) => ({ type, value }));
        this.filteredList = this.list;
      });
  }

  //Some bool values for filtering of customers
  public gambling: boolean = false;
  public onGamblingChanged(value: boolean) {
    this.gambling = value;
  }
  public dancing: boolean = false;
  public onDancingChanged(value: boolean) {
    this.dancing = value;
  }
  public food: boolean = false;
  public onFoodChanged(value: boolean) {
    this.food = value;
  }
  public sleep: boolean = false;
  public onSleepChanged(value: boolean) {
    this.sleep = value;
  }
  // End of bool values for customers


  //Method for filtering on customers
  getTest() {
    this.selectedOptions$ = 0;

    //Give selectedOptions a value based on what bools are true
    if (this.gambling) {
      this.selectedOptions$ += 2;
    }
    if (this.dancing) {
      this.selectedOptions$ += 4;
    }
    if (this.food) {
      this.selectedOptions$ += 8;
    }
    if (this.sleep) {
      this.selectedOptions$ += 16;
    }

    this.filteredList = [];

    //Goes through each item in list, to get the filtered items
    for (var n = 0; n < this.list.length; n++) {
      //Gives a value to each filter option based on bit values, and selectedOption bool values
      var binGamb = ((2 * this.list[n].value.filters.gambling) ** 1);
      var binDanc = ((2 * this.list[n].value.filters.dancing) ** 2);
      var binFood = ((2 * this.list[n].value.filters.food) ** 3);
      var binSleep = ((2 * this.list[n].value.filters.sleep) ** 4);

      var binTotal = binGamb + binDanc + binFood + binSleep;
      //Bitwise function which calculates items which meets the filter options
      if (((~this.selectedOptions$) | binTotal) == -1) {
        this.filteredList.push(this.list[n]);
      }
    }
  }
}
