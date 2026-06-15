import { Subject } from "rxjs";
import { OrderModel } from "../../models/entities/order/order-model";

export interface IOrderSubject {    
    getSubject() : Subject<OrderModel>;
}