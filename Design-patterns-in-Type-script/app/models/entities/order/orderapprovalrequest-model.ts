import { OrderModel } from "./order-model";
import { ManagerModel } from "../user/manager-model";

export class OrderApprovalRequestModel {
    public order : OrderModel;
    public requestByManager: ManagerModel;
    private rejected = false;

    public constructor(order : OrderModel, manager: ManagerModel) {
        this.order = order;
        this.requestByManager = manager;
    }

    public get Rejected() : boolean {
        return this.rejected;
    }

    public reject() : void{
        this.rejected = true;
    }
}