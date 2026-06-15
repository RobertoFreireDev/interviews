import { ItemModel } from "../../models/entities/itens/item-model";
import { OrderModel } from "../../models/entities/order/order-model";
import { OrderApprovalRequestModel } from "../../models/entities/order/orderapprovalrequest-model";
import { ManagerModel } from "../../models/entities/user/manager-model";
import { UserModel } from "../../models/entities/user/user-model";
import { Approvalflow } from "./flows/approval/approvalflow";
import { IitemToOrderService } from "../itens/iitemtoorder-service";
import { IOrderSubject } from "./iordersubject";
export class OrderService {
    private orders : Array<OrderModel> = [];

    constructor(private itemService : IitemToOrderService,
                private orderSubject : IOrderSubject){
    }

    public getOrderByItemId(itemId : string) : OrderModel {
        return this.orders.find(o => o.Item.id == itemId);
    }
    
    public getIndexOfOrderById(orderId : string) : number {
        return this.orders.findIndex(o => o.id == orderId);
    }

    public getAllOrders() : Array<OrderModel> {
        return this.orders;
    }

    public placeOrder(user: UserModel, item : ItemModel) : void {
        const itemAssociateWithUser = this.itemService.associateUserToItem(item.id, user);
        if (itemAssociateWithUser) {
            const newOrder = new OrderModel(itemAssociateWithUser);
            this.orderSubject.getSubject().next(newOrder);
            this.orders.push(newOrder);
            console.log(`Purcharse of ${ item.description } costing ${ item.getPrice() } made for user: ${ user.name }`);
        }          
    }
    
    public approveOrder(requestByUser : ManagerModel, orderId : string) : void {
        const indexOfOrderToBeApproved = this.getIndexOfOrderById(orderId);
        if (!this.doesOrderExist(indexOfOrderToBeApproved, orderId)) return;
        const orderToBeApproved = this.orders[indexOfOrderToBeApproved]; 
        const approved = Approvalflow.run(new OrderApprovalRequestModel(orderToBeApproved,requestByUser));
        if (approved) orderToBeApproved.approve();
    }

    public rejectOrder(orderId : string) : void {
        const indexOfOrderToBeApproved = this.getIndexOfOrderById(orderId);
        if (!this.doesOrderExist(indexOfOrderToBeApproved, orderId)) return;
        this.orders[indexOfOrderToBeApproved].reject();
    }

    private doesOrderExist(indexOfOrder : number, orderId : string) : boolean {
        if (indexOfOrder == -1) {
            console.log(`Order with id ${orderId} not found`);
            return false;
        }
        return true;
    }
}