import { OrderStateEnum } from "../../../enums/stateEnum";
import { IOrderState } from "./iorderstate";

export interface IOrderStateFactory {
    getOrderStateByEnum(stateEnum : OrderStateEnum)  : IOrderState;
}