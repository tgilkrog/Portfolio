import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { User } from '../entities/user';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServUserService } from '../Services/serv-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private data: ApiService, private servUser: ServUserService, private formBuilder: FormBuilder, private router: Router) { }
  user: User = new User("","","");
  loginForm: FormGroup;
  message: string;
  returnUrl: string;
  model: any;

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userid: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.returnUrl = '/home';
    this.data.logout();
  }

  get f() { return this.loginForm.controls };

  login() {
    //Checks if the login form is invalid, returns if invalid
    if (this.loginForm.invalid) {
      return;
    }
    else {
      //Checks of the user exists
      if (this.getUser(this.f.userid.value, this.f.password.value) !== null) {
        console.log("Login successful");
        localStorage.setItem('isLoggedIn', "true");
        setTimeout(() => {
          //Goes to the front page after a delay
          window.location.href = 'http://localhost:4200/home'
        }, 2000)
      }
      else {
        this.message = "Please check your userid and password";
      }
    }
  }

  getUser(username: string, password: string) {
    //Gets the user with username and password
    this.servUser.getUserByNameAndPass(username, password)
      .toPromise()
      .then((res) => {
        this.user = res;
        console.log(this.user);
        //Store some information about the user localy, to be used in other places.
        localStorage.setItem('tokenName', this.user['username']);
        localStorage.setItem('tokenId', this.user['userID']);
        localStorage.setItem('tokenCusId', this.user['cusId']);
        debugger;
      })
      .catch(err => { console.log(err) });
  }

  createUser(username: string, password: string, email: string) {
    this.servUser.createUser(username, password, email);
  }

  onClickMe() {
    //Function for changing the login and create user bokses
    var x = document.getElementById("myDIV");
    var z = document.getElementById("myDIV2");
    if (x.style.display === "none") {
        x.style.display = "block";
        z.style.display = "none";
    } else {
        x.style.display = "none";
        z.style.display = "block";
    }
  }
}
