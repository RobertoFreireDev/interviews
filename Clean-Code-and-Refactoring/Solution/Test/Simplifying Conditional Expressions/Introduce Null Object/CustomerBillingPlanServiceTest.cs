using Simplifying_Conditional_Expressions.Introduce_Null_Object.Services;
using SimplifyingConditionalExpressions.IntroduceNullObject.Entities;
using SimplifyingConditionalExpressions.IntroduceNullObject.Enums;
using System;
using Xunit;

namespace Test.Simplifying_Conditional_Expressions.Introduce_Null_Object
{
    public class CustomerBillingPlanServiceTest
    {

        [Fact(DisplayName = "Must Get Plan Of Customer")]
        [Trait("Introduce Null Object", "CustomerBillingPlanService")]
        public void MustGetPlanOfCustomer()
        {
            var customerBillingPlanService = new CustomerBillingPlanService();
            Guid id = Guid.NewGuid();
            var customer = new Customer(id,"Carlos Rosa",BillingPlanEnum.Premium);
            var result = customerBillingPlanService.GetPlan(customer);

            Assert.Equal(BillingPlanEnum.Premium.ToString(), result.BillingPlan);
            Assert.Equal(id, result.CustomerId);
        }

        [Fact(DisplayName = "Must Get Basic Plan Of Null Customer")]
        [Trait("Introduce Null Object", "CustomerBillingPlanService")]
        public void MustGetBasicPlanOfNullCustomer()
        {
            var customerBillingPlanService = new CustomerBillingPlanService();
            var result = customerBillingPlanService.GetPlan(null);

            Assert.Equal(BillingPlanEnum.Basic.ToString(), result.BillingPlan);
            Assert.Equal(Guid.Empty, result.CustomerId);
        }
    }
}
