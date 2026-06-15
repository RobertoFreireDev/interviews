import { ItemTypeEnum } from "../../../enums/itemTypeEnum";
import { RegionEnum } from "../../../enums/regionEnum";
import { ItemModel } from "./item-model";

export class ServiceModel extends ItemModel {
    private pricePerHour : number;
    private hours : number;

    constructor(description : string, pricePerHour : number, hours : number, region : RegionEnum) {
        super(description,region);
        this.pricePerHour = pricePerHour;
        this.hours = hours;
        this.type = ItemTypeEnum.SERVICE;
    }

    public getPrice() : number {
        return this.pricePerHour * this.hours;
    } 
}