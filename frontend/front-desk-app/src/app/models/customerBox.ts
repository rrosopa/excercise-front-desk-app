import { ICustomer } from "./customer";
import { IStorageArea } from "./storageArea";
import { IBoxStatus } from "./boxStatus";
import { IBaseEntity } from "./baseEntity";

export interface ICustomerBox extends IBaseEntity<string> {
    customerId: string;
    customer: ICustomer;
    label: string;
    storageAreaId: string;
    storageArea: IStorageArea;
    boxStatusId: string;
    boxStatus: IBoxStatus;
}