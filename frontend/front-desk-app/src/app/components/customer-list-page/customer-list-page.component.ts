import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-list-page',
  templateUrl: './customer-list-page.component.html',
  styleUrls: ['./customer-list-page.component.scss']
})
export class CustomerListPageComponent implements OnInit {

  constructor(
    private _customerService: CustomerService
  ) { }

  _customers: ICustomer[] = [];
  _columns: string[] = ['id', 'name', 'phoneNumber', 'action']

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(){
    this._customerService
      .getCustomers()
      .subscribe(x => {
        this._customers = x.data;
    });
  }
}
