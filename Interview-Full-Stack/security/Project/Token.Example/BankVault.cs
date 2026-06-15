namespace Token.Example
{
    public interface IBankVaultForAppPay
    {
        Guid SetToken(PurchaseInfo creditCard);
    }

    public interface IBankVaultForAcquirer
    {
        bool Validate(Guid token, int value);
    }

    public class BankVault : IBankVaultForAppPay, IBankVaultForAcquirer
    {
        private Dictionary<Guid, PurchaseInfo> Tokens = new Dictionary<Guid, PurchaseInfo>();

        public Guid SetToken(PurchaseInfo creditCard)
        {
            var token = Guid.NewGuid();
            Tokens.Add(token, creditCard);
            return token;
        }

        public bool Validate(Guid token, int value)
        {
            if (!Tokens.ContainsKey(token)) return false;

            var purchaseInfo = Tokens.GetValueOrDefault(token);

            if (purchaseInfo?.MONEY != value) return false;

            // Debit value from user account;

            return true;
        }
    }
}
