import { OrderApprovalRequestModel } from "../../../../models/entities/order/orderapprovalrequest-model";
import { NotifyOrderManagerHandler } from "./notification/notifyordermanager";
import { ValidateOrderManagerHandler } from "./validation/validateordermanager";
import { ValidateResponsibleForRegionHandler } from "./validation/validateresponsibleforregion";

export class Approvalflow {
    public static run(orderRequest : OrderApprovalRequestModel) : boolean {
        const validateOrderManager = new ValidateOrderManagerHandler();
        const validateResponsibleForRegion = new ValidateResponsibleForRegionHandler();        
        const notifyOrderManager = new NotifyOrderManagerHandler();
        validateOrderManager.setNext(validateResponsibleForRegion).setNext(notifyOrderManager);

        console.log(`Beginning approval request for order ${orderRequest.order.id}`);
        orderRequest = validateOrderManager.handle(orderRequest);
        if (orderRequest && orderRequest.Rejected) {
            console.log("Order was not approved!");
            return false;
        }
        return true;
    }
}