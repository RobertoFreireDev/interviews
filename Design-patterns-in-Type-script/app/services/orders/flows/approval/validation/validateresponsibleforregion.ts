import { OrderApprovalRequestModel } from "../../../../../models/entities/order/orderapprovalrequest-model";
import { Handler } from "../../handler";

export class ValidateResponsibleForRegionHandler extends Handler {
    public handle(request: OrderApprovalRequestModel): OrderApprovalRequestModel {
        console.log('Validating Responsible For Region');
        if (request.requestByManager.Region !== request.order.Item.region) {
            console.log(`User ${request.requestByManager.name} is not responsible for the region ${request.order.Item.region}`);
            request.reject(); 
            return request;
        }            
        return super.handle(request);
    }
}