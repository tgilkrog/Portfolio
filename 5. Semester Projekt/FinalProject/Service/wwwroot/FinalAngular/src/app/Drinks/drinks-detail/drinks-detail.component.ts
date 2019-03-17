import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { ActivatedRoute } from '@angular/router';
import { ServDrinkService } from '../../Services/serv-drink.service';

@Component({
  selector: 'app-drinks-detail',
  templateUrl: './drinks-detail.component.html',
  styleUrls: ['./drinks-detail.component.css']
})
export class DrinksDetailComponent implements OnInit {
  id: Object;
  drink: Object;

  constructor(private data: ApiService, private servDrink: ServDrinkService, private _route: ActivatedRoute) {
    this._route.params.subscribe(params => this.id = params.id);

    this._route.url.subscribe(url => {
      this.servDrink.getDrinkById(this.id).subscribe(data => this.drink = data);
      debugger;
    });
  }

  ngOnInit() {
  }

}
