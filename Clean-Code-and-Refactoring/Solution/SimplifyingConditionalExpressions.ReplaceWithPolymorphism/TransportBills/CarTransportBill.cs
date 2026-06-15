namespace SimplifyingConditionalExpressions.ReplaceWithPolymorphism.TransportBills
{
    public class CarTransportBill : TransportBill
    {
        public CarTransportBill(TransportationTypeEnum transportationType, int hours)
            : base(transportationType, hours, 0) { }

        public override double GetBill()
        {
            return TransportBill.CAR_HOUR_PRICE * Hours;
        }
    }
}
