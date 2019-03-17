import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-top-banner',
  templateUrl: './top-banner.component.html',
  styleUrls: ['./top-banner.component.css']
})
export class TopBannerComponent implements OnInit {
  username: string;
  userId: string;
  location: string;

  constructor(private data: ApiService, private router: Router) {
    router.events.subscribe(evt => {
      if (evt instanceof NavigationEnd) {
        this.location = this.router.url;
      }
    });
  }

  ngOnInit() {
    //Gets som user information which is stored locally
    this.username = localStorage.getItem('tokenName');
    this.userId = localStorage.getItem('tokenId');
  }

  logout(): void {
    //Method for loggin out
    console.log("Logout");
    this.data.logout();
    window.location.href = 'http://localhost:4200/home';
  }
}
