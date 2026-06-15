using System;

namespace SimplifyingConditionalExpressions.ReplaceWithPolymorphism
{
    /*
     * 
     * Problem:
     * You have a conditional that performs various actions depending on object type or properties.
     * 
     * Solution:
     * Create subclasses matching the branches of the conditional. 
     * In them, create a shared method and move code from the corresponding branch of the 
     * conditional to it. Then replace the conditional with the relevant method call. 
     * The result is that the proper implementation will be attained via polymorphism 
     * depending on the object class.
     * 
    */
    public abstract class TransportBill
    {
        protected TransportationTypeEnum TransportationType;
        protected int Hours;
        protected int LoadKg;
        protected static readonly int BUS_KG_PRICE = 7;
        protected static readonly int CAR_HOUR_PRICE = 100;

        public TransportBill(TransportationTypeEnum transportationType,
                            int hours,
                            int loadKg) {
            Hours = hours;
            LoadKg = loadKg;
            TransportationType = transportationType;
        }

        public abstract double GetBill();
    }
}
