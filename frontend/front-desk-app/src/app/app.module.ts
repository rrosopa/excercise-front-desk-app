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
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';

import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CustomerListPageComponent } from './components/customer-list-page/customer-list-page.component';
import { StorageListPageComponent } from './components/storage-list-page/storage-list-page.component';
import { CustomerEditPageComponent } from './components/customer-edit-page/customer-edit-page.component';
import { BoxesCreateComponent } from './components/boxes-create/boxes-create.component';
import { BoxesViewComponent } from './components/boxes-view/boxes-view.component';
import { BoxTypesService } from './services/box-types.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

@NgModule({
  declarations: [
    AppComponent,
    CustomerListPageComponent,
    StorageListPageComponent,
    CustomerEditPageComponent,
    BoxesCreateComponent,
    BoxesViewComponent,
    BoxesCreateComponent,
    BoxesViewComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    AppRoutingModule,    
    HttpClientModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule
  ],
  providers: [
    CustomerService,
    StorageService,
    DataService,
    BoxTypesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
