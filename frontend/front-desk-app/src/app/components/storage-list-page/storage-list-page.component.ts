import { Component, OnInit } from '@angular/core';
import { IStorageFacilityAreaSummary } from 'src/app/models/storageFacilityAreaSummary';
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

  _storages: IStorageFacilityAreaSummary[] = [];
  _columns: string[] = ['facility', 'area', 'capacity', 'remainingCapacity'];

  ngOnInit(): void {
    this.getStorages();
  }

  getStorages(){
    this._storageService
      .getStorageFacilityAreaSummary()
      .subscribe(x => {
        this._storages = x.data;
    });
  }
}
