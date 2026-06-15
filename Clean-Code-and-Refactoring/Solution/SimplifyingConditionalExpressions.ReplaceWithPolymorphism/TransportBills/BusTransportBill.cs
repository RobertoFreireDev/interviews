namespace SimplifyingConditionalExpressions.ReplaceWithPolymorphism.TransportBills
{
    public class BusTransportBill : TransportBill
    {
        public BusTransportBill(TransportationTypeEnum transportationType, int loadKg) 
            : base (transportationType,0, loadKg){ }

        public override double GetBill()
        {
            return TransportBill.BUS_KG_PRICE * LoadKg;
        }
    }
}
