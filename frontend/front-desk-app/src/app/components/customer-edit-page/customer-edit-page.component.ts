import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
    private _customerService: CustomerService
  ) { }

  ngOnInit(): void {
  }

  save(){
    var data = this._customerForm.value;
    this._customerService
      .add(data.firstName, data.lastName, data.phone)
      .subscribe(x => {
        if(x.errorMessage){

        }
        else{
          // redirrect
        }
      })
  }
}
