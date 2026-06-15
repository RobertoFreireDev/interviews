using SimplifyingConditionalExpressions.IntroduceNullObject.Enums;
using System;

namespace SimplifyingConditionalExpressions.IntroduceNullObject.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        private BillingPlan BillingPlan { get; set; }

        public Customer(Guid id,
            string name,
            BillingPlanEnum billingPlan = BillingPlanEnum.Basic)
        {
            Id = id;
            Name = name;
            BillingPlan = new BillingPlan(billingPlan);
        }

        public virtual BillingPlanEnum GetPlan()
        {
            return BillingPlan.Plan;
        }
    }
}
