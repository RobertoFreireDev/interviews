import { OrderStateEnum } from "../../../../enums/stateEnum";
import { OrderModel } from "../../../../models/entities/order/order-model";
import { IOrderState } from "../iorderstate";

export class CreatedStateForServiceItem implements IOrderState {
    context : OrderModel;

    constructor(){
        console.log(`Order Service Manager will be notified about this order`);
    }

    public approve() : boolean  {
        console.log(`Order with id ${this.context.id} was approved successfully`);
        this.context.changeState(OrderStateEnum.APPROVED);
        return true;
    }

    public reject() : boolean {
        console.log(`Order with id ${this.context.id} was rejected`);
        this.context.changeState(OrderStateEnum.REJECTED);
        return true;
    }
}