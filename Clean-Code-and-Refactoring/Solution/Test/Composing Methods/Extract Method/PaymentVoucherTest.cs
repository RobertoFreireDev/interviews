using ComposingMethods.ExtractMethod;
using ComposingMethods.ExtractMethod.Enums;
using ComposingMethods.ExtractMethod.Util;
using Xunit;

namespace Test.Composing_Methods.Extract_Method
{
    public class PaymentVoucherTest
    {
        [Fact(DisplayName = "Must Generate Voucher To Print")]
        [Trait("Extract Method", "PaymentVoucher")]
        public void MustGenerateVoucherToPrint()
        {
            decimal value = 100;
            CurrencyEnum currency = CurrencyEnum.Brazil;
            string buyer = "Vitória Mendez Carvalho Alves";
            var paymentVoucher = new PaymentVoucher(value, buyer, currency);

            var result = paymentVoucher.GenerateVoucherToPrint();

            var expectedValue = ConvertCurrencyToString.Convert(currency) + " " + value;

            Assert.Equal(buyer.Substring(0, 10), result.Buyer);
            Assert.Equal(expectedValue, result.Value);
        }
    }
}
