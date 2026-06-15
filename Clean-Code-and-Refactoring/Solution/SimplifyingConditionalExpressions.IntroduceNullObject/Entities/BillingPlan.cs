using SimplifyingConditionalExpressions.IntroduceNullObject.Enums;

namespace SimplifyingConditionalExpressions.IntroduceNullObject.Entities
{
    public class BillingPlan
    {
        public BillingPlanEnum Plan { get; private set; }

        public BillingPlan(BillingPlanEnum plan) {
            Plan = plan;
        }
    }
}
