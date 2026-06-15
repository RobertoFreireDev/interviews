import { OrderStateEnum } from "../../../enums/stateEnum";
import { IOrderState } from "./iorderstate";
import { ApprovedStateForServiceItem } from "./services/approvedstateforserviceitem";
import { CreatedStateForServiceItem } from "./services/createdstateforserviceitem";
import { DoneStateForServiceItem } from "./services/donestateforserviceitem";
import { RejectedStateForServiceItem } from "./services/rejectedstateforserviceitem";

const ERROR_MESSAGE_STATE_NOT_FOUND = "State not found";

export class OrderStateForServiceItemFactory {
    public static getOrderStateByEnum(stateEnum : OrderStateEnum)  : IOrderState  {
        switch(stateEnum){
            case OrderStateEnum.CREATED:
                return new CreatedStateForServiceItem();
            case OrderStateEnum.APPROVED:
                return new ApprovedStateForServiceItem(); 
            case OrderStateEnum.DONE:
                return new DoneStateForServiceItem();
            case OrderStateEnum.REJECTED:
                return new RejectedStateForServiceItem(); 
            default:
                throw ERROR_MESSAGE_STATE_NOT_FOUND;
        }
    }
}