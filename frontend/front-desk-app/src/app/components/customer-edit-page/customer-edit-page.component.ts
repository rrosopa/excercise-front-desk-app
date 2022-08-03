import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-edit-page',
  templateUrl: './customer-edit-page.component.html',
  styleUrls: ['./customer-edit-page.component.scss']
})
export class CustomerEditPageComponent implements OnInit {

  _customerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.maxLength(100)]),    
    lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    phone: new FormControl('', [Validators.required, Validators.maxLength(20)])
  });

  constructor(
    private _customerService: CustomerService,
    private _router: Router
  ) { }

  ngOnInit(): void {
  }

  save(){
    var data = this._customerForm.value;
    this._customerService
      .addCustomer(data.firstName, data.lastName, data.phone)
      .subscribe(
        x => {
          if(x.errorMessage){
            alert(x.errorMessage);
          }
          else{
            this._router.navigate(['customers']);
          }
        },
        e => {        
          alert(e.errorMessage);
        }
      );
  }
}
