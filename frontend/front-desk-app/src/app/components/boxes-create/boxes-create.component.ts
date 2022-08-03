import { Component, OnInit } from '@angular/core';
import { FormArrayName, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IBoxType } from 'src/app/models/boxType';
import { IStorageArea } from 'src/app/models/storageArea';
import { IStorageAreaDto } from 'src/app/models/storageAreaDto';
import { IStorageFacility } from 'src/app/models/storageFacility';
import { BoxTypesService } from 'src/app/services/box-types.service';
import { CustomerService } from 'src/app/services/customer.service';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-boxes-create',
  templateUrl: './boxes-create.component.html',
  styleUrls: ['./boxes-create.component.scss']
})
export class BoxesCreateComponent implements OnInit {

  _customerId: string = '';
  _form: any;

  _boxTypes: IBoxType[] = [];
  _storage: IStorageFacility[] = [];
  _storageAreas: IStorageAreaDto[] = [];

  constructor(
    private _customerService: CustomerService,
    private _boxTypeService: BoxTypesService,
    private _storageService: StorageService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this._route.params.subscribe(params => {
      this._customerId = params['id'];
   });

    this.getBoxTypes();
    this.getStorage();
    
    this._form = new FormGroup({
      label: new FormControl('', [Validators.required, Validators.maxLength(100)]),    
      boxTypeId: new FormControl('', [Validators.required]),    
      storageFacilityId: new FormControl(''),
      storageAreaId: new FormControl('', [Validators.required])
    });

    this.onChanges();
  }

  onChanges(): void {
    this._form.controls['storageFacilityId'].valueChanges.subscribe((v: string) => {
      console.log(v);
      this.getStorageAreas();
    });
  }
  
  getStorage(){
    this._storageService
      .getStorageFacilities()
      .subscribe(x => {
        this._storage = x.data;
      });
  }

  getStorageAreas(){
    let id = this._form.value.storageFacilityId;
    if(id){
      this._storageService
        .getStorageAreas(id)
        .subscribe(x => {
          this._storageAreas = x.data;
        });

    }
  }

  getBoxTypes(){
    this._boxTypeService
      .getList()
      .subscribe(x => {
        this._boxTypes = x.data;
      });
  }

  storeBox(){
    var data = this._form.value;
    this._customerService
      .addBox(this._customerId, data.label, data.boxTypeId, data.storageAreaId)
      .subscribe(
        x => {
          if(x.errorMessage){
            alert(x.errorMessage);
          }
          else{
            this._router.navigate(['customers', this._customerId, 'boxes']);
          }
        },
        e => {        
        alert(e.errorMessage);
        }
      );
  }
}
