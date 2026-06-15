using ComposingMethods.RemoveAssignmentstoParameters;
using ComposingMethods.RemoveAssignmentstoParameters.Discounts;
using Xunit;

namespace Test.Composing_Methods.Remove_Assignments_to_Parameters
{
    public class DiscountTest
    {
        [Fact(DisplayName = "Must Apply Discount")]
        [Trait("Remove Assignments to Parameters", "Discount")]
        public void MustApply10PercentDiscount() 
        {
            var productValue = 100;
            var product = new Product()
            {
                value = productValue,
                quantity = 100
            };

            var result = Discount.Apply(product);

            Assert.Equal(_10PercentDiscount.ApplyDiscount(productValue), result);
        }

        [Fact(DisplayName = "Must Not Change Parameters During Discount")]
        [Trait("Remove Assignments to Parameters", "Discount")]
        public void MustNotChangeParametersDuringDiscount()
        {
            var productValue = 100;
            var product = new Product()
            {
                value = productValue,
                quantity = 100
            };

            Discount.Apply(product);

            Assert.Equal(productValue, product.value);
        }
    }
}
