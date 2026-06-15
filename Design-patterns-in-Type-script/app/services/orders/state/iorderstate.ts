import { OrderModel } from "../../../models/entities/order/order-model";

export interface IOrderState  {
    context : OrderModel;
    approve() : boolean;
    reject() : boolean;
}