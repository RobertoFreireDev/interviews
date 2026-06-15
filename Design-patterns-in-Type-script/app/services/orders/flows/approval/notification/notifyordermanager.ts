import { Email } from "../../../../../infra/email";
import { OrderApprovalRequestModel } from "../../../../../models/entities/order/orderapprovalrequest-model";
import { Handler } from "../../handler";

export class NotifyOrderManagerHandler extends Handler {
    public handle(request: OrderApprovalRequestModel): OrderApprovalRequestModel {
        console.log('Notifing Order Manager');
        const content = `Order id ${request.order.id} approved`;
        Email.send(content);      
        return super.handle(request);;
    }
}