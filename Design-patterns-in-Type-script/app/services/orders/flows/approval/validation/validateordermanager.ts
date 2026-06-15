import { UserRoleEnum } from "../../../../../enums/userRoleEnum";
import { OrderApprovalRequestModel } from "../../../../../models/entities/order/orderapprovalrequest-model";
import { Handler } from "../../handler";

export class ValidateOrderManagerHandler extends Handler {
    public handle(request: OrderApprovalRequestModel): OrderApprovalRequestModel {
        console.log('Validating Order Manager');
        if (request.requestByManager.role != UserRoleEnum.ORDER_MANAGER) {
            console.log(`User ${request.requestByManager.name} is not a Order Manager`);
            request.reject();
            return request;
        }       
        return super.handle(request);
    }
}