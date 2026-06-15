using SimplifyingConditionalExpressions.ReplaceNestedConditional;
using Xunit;

namespace Test.Simplifying_Conditional_Expressions.Replace_Nested_Conditional_with_Guard_Clauses
{
    public class PaymentTest
    {
        [Theory(DisplayName = "Must Get Pay Amount")]
        [Trait("Replace Nested Conditional with Guard Clauses", "Payment")]
        [InlineData(false, false, false,100, 100)]
        [InlineData(true, false, false, 100, 50)]
        [InlineData(false, true, false, 100, 22)]
        [InlineData(false, false, true, 100, 200)]
        public void MustGetPayAmount(bool isDead, bool isSeparated,
                bool isRetired, double value, double expectedResult)
        {            
            var payment = new Payment(isDead, isSeparated,isRetired, value);

            var result = payment.GetPayAmount();

            Assert.Equal(expectedResult, result);
        }
    }
}
