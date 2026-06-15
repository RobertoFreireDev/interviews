using ComposingMethods.RemoveAssignmentstoParameters.Discounts;

namespace ComposingMethods.RemoveAssignmentstoParameters
{
    public static class Discount
    {
        /*
         * Problem:
         * Some value is assigned to a parameter inside method’s body.
         * 
         * Solution:
         * Use a local variable instead of a parameter.
         * 
        */
        public static double Apply(Product product) {
            double result = product.value;

            if (product.quantity > 50) {
                result = _10PercentDiscount.ApplyDiscount(result);
            }

            return result;
        }
    }
}
