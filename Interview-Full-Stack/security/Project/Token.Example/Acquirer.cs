namespace Token.Example
{
    public interface IAcquirer
    {
        bool ProcessTransaction(Guid token);
    }

    public class AcquirerA : IAcquirer
    {
        private readonly int ValueOfTransaction;

        private readonly IBankVaultForAcquirer _bankVault;

        public AcquirerA(int value, IBankVaultForAcquirer bankVault)
        {
            ValueOfTransaction = value;
            _bankVault = bankVault;
        }
        public bool ProcessTransaction(Guid token)
        {
            return _bankVault.Validate(token, ValueOfTransaction);
        }
    }
}
