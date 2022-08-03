import { IStorageArea } from "./storageArea";
import { IBaseEntity } from "./baseEntity";

export interface IStorageFacility extends IBaseEntity<string> {
    name: string;
    storageAreas: IStorageArea[];
}