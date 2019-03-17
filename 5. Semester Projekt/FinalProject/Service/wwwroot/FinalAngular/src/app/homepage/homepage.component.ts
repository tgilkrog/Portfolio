import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { switchMap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { ApiService } from '../api.service';
import { ServCustomerService } from '../Services/serv-customer.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  results: any[] = [];
  queryField: FormControl = new FormControl();
  public location = '';
  check: boolean = false;
  ShowDropDown: boolean;


  constructor(private route: Router, private servCus: ServCustomerService, private _route: ActivatedRoute) {
    this._route.url.subscribe(url => {
      this.location = this.route.url;
    });
  }

  ngOnInit() {
    //Gets the list of customer to the search bar, with an autosearch
    this.queryField.valueChanges.pipe(
      debounceTime(500), distinctUntilChanged(),
      switchMap(search => this.servCus.getCustomerByName(search)))
      .subscribe(result => {
        this.results = []; this.CheckText();
        Object.keys(result).map(index => {
          this.results.push(result[index]);
        });
      })
  }

  CheckText() {
    //Checks if search field is empty or not
    if (this.queryField.value !== "") {
      this.check = true;
    }
    else {
      this.check = false;
    }
  }

  FocusCheck(focused: boolean) {
    //Check if searchbar is active or not.
    if (focused) {
      this.ShowDropDown = focused;
    }
    else {
      var timer = setTimeout(() => this.ShowDropDown = focused, 200);
    }
  }

  Clear() {
    //Clears the searchbar
    this.queryField.setValue('');
  }

  Search() {
    this.Clear();
  }

  onKeydown(event) {
    //Checks if enter his hit when on the searchbar
    if (event.key === "Enter" && (this.queryField.value.trim() !== "" && this.queryField.value.trim() !== " ")) {
      this.Search();
    }
  }

}
