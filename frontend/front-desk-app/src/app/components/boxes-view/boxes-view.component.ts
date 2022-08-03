import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICustomerBoxDto } from 'src/app/models/customerBox';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-boxes-view',
  templateUrl: './boxes-view.component.html',
  styleUrls: ['./boxes-view.component.scss']
})
export class BoxesViewComponent implements OnInit {

  _customerId: string = '';
  _boxes: ICustomerBoxDto[] = [];
  _columns: string[] = ['id', 'label', 'facility', 'area', 'action']

  constructor(
    private _customerService: CustomerService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      this._customerId = params['id'];
      this.getBoxes();
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

  removeBox(boxId: string){
    this._customerService
      .removeBox(this._customerId, boxId)
      .subscribe(
        x => {
          this.getBoxes();
        },
        e => {
          alert(e.errorMessage);
        }
      )
  }

}
