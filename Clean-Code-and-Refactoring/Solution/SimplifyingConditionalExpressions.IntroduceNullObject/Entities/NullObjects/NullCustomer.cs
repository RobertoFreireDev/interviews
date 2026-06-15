using SimplifyingConditionalExpressions.IntroduceNullObject.Enums;
using System;

namespace SimplifyingConditionalExpressions.IntroduceNullObject.Entities.NullObjects
{
    public class NullCustomer : Customer
    {
        public NullCustomer() : base(Guid.Empty, "", BillingPlanEnum.Basic) { }

        public override BillingPlanEnum GetPlan()
        {
            return BillingPlanEnum.Basic;
        }
    }
}
