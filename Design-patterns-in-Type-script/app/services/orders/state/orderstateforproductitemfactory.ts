import { OrderStateEnum } from "../../../enums/stateEnum";
import { IOrderState } from "./iorderstate";
import { ApprovedStateForProductItem } from "./product/approvedstateforproductitem";
import { CreatedStateForProductItem } from "./product/createdstateforproductitem";
import { DoneStateForProductItem } from "./product/donestateforproductitem";
import { RejectedStateForProductItem } from "./product/rejectedstateforproductitem";

const ERROR_MESSAGE_STATE_NOT_FOUND = "State not found";

export class OrderStateForProductItemFactory {
    public static getOrderStateByEnum(stateEnum : OrderStateEnum)  : IOrderState  {
        switch(stateEnum){
            case OrderStateEnum.CREATED:
                return new CreatedStateForProductItem();
            case OrderStateEnum.APPROVED:
                return new ApprovedStateForProductItem(); 
            case OrderStateEnum.DONE:
                return new DoneStateForProductItem();
            case OrderStateEnum.REJECTED:
                return new RejectedStateForProductItem(); 
            default:
                throw ERROR_MESSAGE_STATE_NOT_FOUND;
        }
    }
}