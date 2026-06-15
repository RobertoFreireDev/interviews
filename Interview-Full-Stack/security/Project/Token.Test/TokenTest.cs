using FluentAssertions;
using Token.Example;
using Xunit;

namespace Token.Test
{
    public class TokenTest
    {
        [Fact]
        public void Must_Process_Transaction()
        {
            var value = 1738; // 17,38;

            var purchaseInfo = new PurchaseInfo()
            {
                BRAND = "VISA",
                NUMBER = "4011845177808174",
                BANK = "BOKF, N.A.",
                NAME = "Jodmos Kharsack",
                CVV = "448",
                EXPIRY = "09/2028",
                MONEY = value
            };

            var bankVault = new BankVault();
            var acquirerA = new AcquirerA(value, bankVault);

            var googlePay = new GooglePay(acquirerA, bankVault);

            var result = googlePay.Pay(purchaseInfo);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_WrongValue_Must_Not_Process_Transaction()
        {
            var value = 1738; // 17,38

            var purchaseInfo = new PurchaseInfo()
            {
                BRAND = "VISA",
                NUMBER = "4011845177808174",
                BANK = "BOKF, N.A.",
                NAME = "Jodmos Kharsack",
                CVV = "448",
                EXPIRY = "09/2028",
                MONEY = 1000 // 10,00
            };

            var bankVault = new BankVault();
            var acquirerA = new AcquirerA(value, bankVault);

            var googlePay = new GooglePay(acquirerA, bankVault);

            var result = googlePay.Pay(purchaseInfo);

            result.Should().BeFalse();
        }
    }
}