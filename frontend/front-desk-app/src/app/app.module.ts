import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { CustomerService } from './services/customer.service';
import { StorageService } from './services/storage.service';
import { DataService } from './services/data.service';


import {MatToolbarModule} from '@angular/material/toolbar'
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';

import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CustomerListPageComponent } from './components/customer-list-page/customer-list-page.component';
import { StorageListPageComponent } from './components/storage-list-page/storage-list-page.component';
import { CustomerEditPageComponent } from './components/customer-edit-page/customer-edit-page.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListPageComponent,
    StorageListPageComponent,
    CustomerEditPageComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,    
    HttpClientModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    ReactiveFormsModule
  ],
  providers: [
    CustomerService,
    StorageService,
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
