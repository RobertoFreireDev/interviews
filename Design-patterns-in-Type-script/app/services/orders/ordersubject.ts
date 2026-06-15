import { Subject } from "rxjs";
import { OrderModel } from "../../models/entities/order/order-model";
import { IOrderSubject } from "./iordersubject";

export class OrderSubject implements IOrderSubject {    
    private orderSubject = new Subject<OrderModel>();

    public getSubject() : Subject<OrderModel>{
        return this.orderSubject;
    }
}