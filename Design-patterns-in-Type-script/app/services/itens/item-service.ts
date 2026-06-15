import { RegionEnum } from '../../enums/regionEnum';
import { EventHub } from '../../infra/eventhub';
import { ItemModel } from '../../models/entities/itens/item-model';
import { ProductModel } from '../../models/entities/itens/product-model';
import { ServiceModel } from '../../models/entities/itens/service-model';
import { UserModel } from '../../models/entities/user/user-model';
import { IItemConversionAdapter } from './iitemconversionadapter';
import { IitemToOrderService } from './iitemtoorder-service';

export class ItemService implements IitemToOrderService {
    private itens : Array<ItemModel> = [
        new ServiceModel("Locar Quadra",100,2,RegionEnum.NORTH),
        new ProductModel("Bola",10.30,RegionEnum.SOUTH)
    ];

    /*    Dependency Injection  */
    constructor(private itemConversionAdapter : IItemConversionAdapter){
    }

    public addItem(item : ItemModel) : void {
        this.itens.push(item);
        EventHub.send(this.itemConversionAdapter.convert(item));
    }

    public getAll() : Array<ItemModel> {
        return this.itens;
    }

    public associateUserToItem(itemId : string, user : UserModel) : ItemModel {
        const itemIndex = this.getIndexOfItemById(itemId);
        if (this.validateIndex(itemIndex, itemId) && this.validateUserInItem(itemIndex)) {
            this.itens[itemIndex].user = user;
            return this.itens[itemIndex];
        }        
        return null;
    }

    private getIndexOfItemById(itemId : string) : number {
        return this.itens.findIndex(i => i.id == itemId);
    }

    private validateIndex(itemIndex : number, itemId : string) : boolean {
        if (itemIndex != -1) return true
        console.log(`Item ${ itemId } doesn't exist`);
        return false;
    }

    private validateUserInItem(itemIndex : number) : boolean {
        if (!this.itens[itemIndex].user) return true
        console.log(`Item ${ this.itens[itemIndex].description } already has a user`);
        return false;
    }
}