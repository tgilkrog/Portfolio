import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { CustomerListComponent } from './Customer/customer-list/customer-list.component';
import { CustomerDetailComponent } from './Customer/customer-detail/customer-detail.component';
import { DrinksListComponent } from './Drinks/drinks-list/drinks-list.component';
import { DrinksDetailComponent } from './Drinks/drinks-detail/drinks-detail.component';
import { LoginComponent } from './login/login.component';
import { UserpageComponent } from './userpage/userpage.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home', component: HomepageComponent, data: { breadcrumb: 'Forside' },
    children: [
      {
        path: 'customers', component: CustomerListComponent, data:{breadcrumb: 'Bar/klubber'},
        children: [
          { path: ':id/:breadcrumb', component: CustomerDetailComponent }
        ]
      },
      {
        path: 'drinks', component: DrinksListComponent, data:{breadcrumb: 'Drinks'},
        children: [
          { path: ':id/:breadcrumb', component: DrinksDetailComponent }
        ]
      },
      { path: 'login', component: LoginComponent, data: { breadcrumb: 'Log ind' } },
      { path: 'userpage/:id/:breadcrumb', component: UserpageComponent, canActivate: [AuthGuard]  }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
