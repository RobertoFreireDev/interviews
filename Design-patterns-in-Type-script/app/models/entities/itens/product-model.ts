import { ItemTypeEnum } from "../../../enums/itemTypeEnum";
import { RegionEnum } from "../../../enums/regionEnum";
import { ItemModel } from "./item-model";

export class ProductModel extends ItemModel {
    private price : number;

    constructor(description : string, price : number, region : RegionEnum) {
        super(description,region);
        this.price = price;
        this.type = ItemTypeEnum.PRODUCT;
    }

    public getPrice() : number {
        return this.price;
    }    
}