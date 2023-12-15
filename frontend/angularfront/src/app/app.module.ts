import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarComponent } from './car/car.component';
import { ShowCarComponent } from './car/show-car/show-car.component';
import { AddEditCarComponent } from './car/add-edit-car/add-edit-car.component';
import { OwnerComponent } from './owner/owner.component';
import { ShowOwnerComponent } from './owner/show-owner/show-owner.component';
import { AddEditOwnerComponent } from './owner/add-edit-owner/add-edit-owner.component';
import { ServService } from './serv.service';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { Routes } from '@angular/router';
import { AuthService } from './auth.service';

/*const appRoutes: Routes = [
  {path: 'user/login', component: UserLoginComponent},
  {path: 'user/register', component: UserRegisterComponent},

]*/

@NgModule({
  declarations: [
    AppComponent,
    CarComponent,
    ShowCarComponent,
    AddEditCarComponent,
    OwnerComponent,
    ShowOwnerComponent,
    AddEditOwnerComponent,
    NavBarComponent,
    UserLoginComponent,
    UserRegisterComponent

   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [ServService,AuthService],
  bootstrap: [AppComponent],
})
export class AppModule { }
