import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBannerComponent } from './top-banner/top-banner.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CustomerListComponent } from './Customer/customer-list/customer-list.component';
import { CustomerDetailComponent } from './Customer/customer-detail/customer-detail.component';
import { FormsModule, FormControl, ReactiveFormsModule } from '@angular/forms';
import { DrinksListComponent } from './Drinks/drinks-list/drinks-list.component';
import { DrinksDetailComponent } from './Drinks/drinks-detail/drinks-detail.component';
import { LoginComponent } from './login/login.component';
import { UserpageComponent } from './userpage/userpage.component';
import { AuthGuard } from './auth.guard';
import { BreadcrumbsModule, BreadcrumbComponent } from "ng6-breadcrumbs";

@NgModule({
  declarations: [
    AppComponent,
    TopBannerComponent,
    HomepageComponent,
    CustomerListComponent,
    CustomerDetailComponent,
    DrinksListComponent,
    DrinksDetailComponent,
    LoginComponent,
    UserpageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    HttpClientModule,
    FormsModule,
    BreadcrumbsModule,
    ReactiveFormsModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
