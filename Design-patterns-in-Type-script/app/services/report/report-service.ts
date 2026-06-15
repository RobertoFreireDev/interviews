import { ReportDataModel } from "../../models/entities/report/reportdata-model";
import { IOrderSubject } from "../orders/iordersubject";

export class ReportService {
    private reportData = new Map<string,ReportDataModel>();

    constructor(private orderSubject : IOrderSubject){
        orderSubject.getSubject().subscribe(order => {
            let reportDataModel = new ReportDataModel();
            reportDataModel = {
                orderId : order.id,
                itemId : order.Item.id,
                item : order.Item.description,
                region : order.Item.region
            }
            
            this.reportData.set(order.id,reportDataModel);
        });
    }

    public showReportData() : void {
        console.table(Array.from(this.reportData.values()));
    }
}