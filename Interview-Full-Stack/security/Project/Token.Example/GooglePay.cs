namespace Token.Example
{
    public interface IAppPay
    {
        bool Pay(PurchaseInfo purchaseInfo);
    }

    public class GooglePay : IAppPay
    {
        private readonly IAcquirer _acquirer;
        private readonly IBankVaultForAppPay _bankVault;

        public GooglePay(
            IAcquirer acquirer,
            IBankVaultForAppPay bankVault)
        {
            _acquirer = acquirer;
            _bankVault = bankVault;
        }

        public bool Pay(PurchaseInfo purchaseInfo)
        {
            var token = _bankVault.SetToken(purchaseInfo);

            // _acquirer only knows the token and the value of transaction
            return _acquirer.ProcessTransaction(token);
        }
    }
}
