using ComposingMethods.ExtractMethod.Enums;
using ComposingMethods.ExtractMethod.Util;

namespace ComposingMethods.ExtractMethod
{
    public class PaymentVoucher
    {
        private decimal Value; 
        private CurrencyEnum Currency;
        private string Buyer;

        public PaymentVoucher(
            decimal value,
            string buyer,
            CurrencyEnum currency) 
        {
            Value = value;
            Buyer = buyer;
            Currency = currency;
        }
        /*
         * Problem:
         * You have a code fragment that can be grouped together.
         * 
         * Solution:
         * Move this code to a separate new method (or function) and replace the old code with a call to the method.
         * 
        */
        public PaymentVoucherToPrint GenerateVoucherToPrint() {
            var voucherToPrint = new PaymentVoucherToPrint() {
                Buyer = GenerateBuyerTruncating(),
                Value = GenerateValueWithCurrency()
            };

            return voucherToPrint;
        }

        private string GenerateValueWithCurrency() 
        {
            string currency = ConvertCurrencyToString.Convert(Currency);
            return currency + " " + Value;
        }

        private string GenerateBuyerTruncating()
        {
            return this.Buyer.Substring(0, 10);
        }
    }
}
