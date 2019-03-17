import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../api.service';
import { ServDrinkService } from '../../Services/serv-drink.service';

@Component({
  selector: 'app-drinks-list',
  templateUrl: './drinks-list.component.html',
  styleUrls: ['./drinks-list.component.css']
})
export class DrinksListComponent implements OnInit {
  list: any[];

  constructor(private data: ApiService, private servDrink: ServDrinkService, private _route: ActivatedRoute) {

    this._route.url.subscribe(url => {
      this.servDrink.getAllDrinks()
        .subscribe(data => {
          this.list = Object.entries(data).map(([type, value]) => ({ type, value }));
        });
    });
  }

  ngOnInit() {
  }

}
