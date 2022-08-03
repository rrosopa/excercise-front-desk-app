import { Component, OnInit } from '@angular/core';
import { IStorageFacility } from 'src/app/models/storageFacility';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-storage-list-page',
  templateUrl: './storage-list-page.component.html',
  styleUrls: ['./storage-list-page.component.scss']
})
export class StorageListPageComponent implements OnInit {

  constructor(
    private _storageService: StorageService
  ) { }

  _storages: IStorageFacility[] = [];

  ngOnInit(): void {
    this.getStorages();
  }

  getStorages(){
    this._storageService
      .getStorageFacilities()
      .subscribe(x => {
        this._storages = x.data;
    });
  }
}
