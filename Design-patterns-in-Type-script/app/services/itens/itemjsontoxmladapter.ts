import { ItemModel } from "../../models/entities/itens/item-model";
import { IItemConversionAdapter } from "./iitemconversionadapter";

export class ItemJsonToXmlAdapter implements IItemConversionAdapter {
    public convert(item : ItemModel) : string {   
        const jsonItem = item.getDetails();
        let xmlContent = "";
        Object.keys(jsonItem).forEach(key => {
            xmlContent += `<${key}>${jsonItem[key]}</${key}>`;
        });
        return `<item>${xmlContent}</item>`;
    }
}