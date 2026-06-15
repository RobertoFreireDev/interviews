import { ItemModel } from "../../models/entities/itens/item-model";
import { UserModel } from "../../models/entities/user/user-model";

/*
Interface Segregation Principle:
Make fine grained interfaces that are client-specific. 
Clients should not be forced to implement interfaces they do not use.”
*/

export interface IitemToOrderService {
    associateUserToItem(itemId : string, user : UserModel) : ItemModel;
}