import { OrderModel } from "../../../../models/entities/order/order-model";
import { IOrderState } from "../iorderstate";

export class RejectedStateForProductItem implements IOrderState {
    context : OrderModel;
    
    public approve() : boolean {
        console.log(`Order with id ${this.context.id} was rejected and can not be approved`);
        return false;
    }

    public reject() : boolean {
        console.log(`Order with id ${this.context.id} was already rejected`);
        return false;
    }
}