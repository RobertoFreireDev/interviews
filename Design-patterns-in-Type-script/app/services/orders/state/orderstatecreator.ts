import { ItemTypeEnum } from "../../../enums/itemTypeEnum";
import { OrderStateEnum } from "../../../enums/stateEnum";
import { IOrderState } from "./iorderstate";
import { IOrderStateFactory } from "./iorderstatefactory";
import { OrderStateForProductItemFactory } from "./orderstateforproductitemfactory";
import { OrderStateForServiceItemFactory } from "./orderstateforserviceitemfactory";

export class OrderStateCreator {
    
    public static createOrderState(type : ItemTypeEnum, stateEnum : OrderStateEnum) : IOrderState {
        /*
        Factory Method: 
        The purpose is to be able to change factories and each factory create its own object for the factory context. 
        But, all orderState objects follows the same contract IOrderState regardless the factory

        Open-Closed Principle: Objects or entities must be open for extension, but closed for modification

        If we continue to use the last approach (having all order status logic for both product or service together) 
        and in case we have to add new types of items in the future, you will have very dirty code, 
        full of conditional conditions that change the application's behavior.

        So now we can create a new factory for each new item type and add/change behaviors 
        by extending the classes instead of modifiying it
         */
        let orderStateFactory : IOrderStateFactory;
        if (type == ItemTypeEnum.PRODUCT) {
            orderStateFactory = OrderStateForProductItemFactory;
        } else if (type == ItemTypeEnum.SERVICE) {
            orderStateFactory = OrderStateForServiceItemFactory;
        }

        return orderStateFactory.getOrderStateByEnum(stateEnum);
    }        
}