import { ItemModel } from "../../models/entities/itens/item-model";

export interface IItemConversionAdapter {
    convert(item : ItemModel) : string;
}