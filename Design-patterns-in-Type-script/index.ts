import { UserModel } from './app/models/entities/user/user-model';
import { ItemService } from './app/services/itens/item-service';
import { ItemJsonToXmlAdapter } from './app/services/itens/itemjsontoxmladapter';
import { OrderService } from './app/services/orders/order-service';
import { OrderSubject } from './app/services/orders/ordersubject';
import { ReportService } from './app/services/report/report-service';

const itemJsonToXmlAdapter = new ItemJsonToXmlAdapter();
const itemService = new ItemService(itemJsonToXmlAdapter);
const orderSubject = new OrderSubject();
const reportService = new ReportService(orderSubject);
const orderService = new OrderService(itemService,orderSubject);
const user = new UserModel("Antônio", 26);
const itens = itemService.getAll();

itens.forEach(i => orderService.placeOrder(user, i));

reportService.showReportData();
