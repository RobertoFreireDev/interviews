import { ItemTypeEnum } from '../../../enums/itemTypeEnum';
import { RegionEnum } from '../../../enums/regionEnum';
import { EntityModel } from '../entity-model';
import { UserModel } from '../user/user-model';

export abstract class ItemModel extends EntityModel {
    description : string;
    user : UserModel;
    region : RegionEnum;
    protected type : ItemTypeEnum;

    public get Type() {
        return this.type;
    }

    constructor(description : string, region : RegionEnum) {
        super();
        this.description = description;
        this.region = region;
    }

    public abstract getPrice();

    public getDetails() : Object {
        return {
            description : this.description,
            price : this.getPrice()
        };
    }
}