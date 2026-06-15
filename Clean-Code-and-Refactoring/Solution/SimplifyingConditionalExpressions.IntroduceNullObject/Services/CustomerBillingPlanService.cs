using Simplifying_Conditional_Expressions.Introduce_Null_Object.Dtos;
using SimplifyingConditionalExpressions.IntroduceNullObject.Entities;
using SimplifyingConditionalExpressions.IntroduceNullObject.Entities.NullObjects;
using System;

namespace Simplifying_Conditional_Expressions.Introduce_Null_Object.Services
{
    public class CustomerBillingPlanService
    {
        /*
         * 
         * Problem
         * Since some methods return null instead of real objects, you have many checks for null in your code.
         * 
         * Solution
         * Instead of null, return a null object that exhibits the default behavior.
         * 
        */
        public CustomerBillingPlanDto GetPlan(Customer customer) {
            customer = customer ?? new NullCustomer();
            var plan = customer.GetPlan();

            return new CustomerBillingPlanDto() {
                CustomerId = customer.Id,
                BillingPlan = plan.ToString()
            };
        }
    }
}
