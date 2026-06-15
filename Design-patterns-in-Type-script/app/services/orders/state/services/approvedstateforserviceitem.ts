import { IOrderState } from "../iorderstate";
import { OrderModel } from "../../../../models/entities/order/order-model";

export class ApprovedStateForServiceItem implements IOrderState {
    context : OrderModel;
     
    public approve()  : boolean {
        console.log(`Order with id ${this.context.id} was already approved`);
        return false;
    }

    public reject() : boolean {
        console.log(`Order with id ${this.context.id} can not be rejected because it was already approved`);
        return false;
    }
}

