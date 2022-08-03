
import { ICustomerBox } from "./customerBox";
import { IBaseEntity } from "./baseEntity";

export interface ICustomer extends IBaseEntity<string> {
    firstName: string;
    lastName: string;
    phoneNumber: string;
    boxes: ICustomerBox[];
}