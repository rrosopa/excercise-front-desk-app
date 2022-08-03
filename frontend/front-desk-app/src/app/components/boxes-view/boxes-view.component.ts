import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICustomerBox } from 'src/app/models/customerBox';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-boxes-view',
  templateUrl: './boxes-view.component.html',
  styleUrls: ['./boxes-view.component.scss']
})
export class BoxesViewComponent implements OnInit {

  _customerId: string = '';
  _boxes: ICustomerBox[] = [];

  constructor(
    private _customerService: CustomerService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      this._customerId = params['id'];
    });
  }

  getBoxes(){
    this._customerService
      .getCustomerBoxes(this._customerId)
      .subscribe(
        x => {
          if(x.errorMessage){
            alert(x.errorMessage);
          }
          else{
            this._boxes = x.data
          }
        },
        e => {        
        alert(e.errorMessage);
        }
      );
  }

}
