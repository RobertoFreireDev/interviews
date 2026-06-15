import { OrderModel } from "../../../../models/entities/order/order-model";
import { IOrderState } from "../iorderstate";

export class DoneStateForServiceItem implements IOrderState {
    context : OrderModel;
    
    public approve() : boolean {
        console.log(`Order with id ${this.context.id} was closed and can not be approved`);
        return false;
    }

    public reject() : boolean {
        console.log(`Order with id ${this.context.id} was closed and can not be rejected`);
        return false;
    }
}