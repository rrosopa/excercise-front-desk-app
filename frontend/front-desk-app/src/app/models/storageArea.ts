import { IStorageFacility } from "./storageFacility";
import { IStorageAreaType } from "./storageAreaType";
import { ICustomerBox } from "./customerBox";
import { IBaseEntity } from "./baseEntity";

export interface IStorageArea extends IBaseEntity<string> {
    storageFacilityId: string;
    storageFacility: IStorageFacility;
    storageAreaTypeId: string;
    name: string;
    storageAreaType: IStorageAreaType;
    totalSpace: number;
    customerBoxes: ICustomerBox[];
}