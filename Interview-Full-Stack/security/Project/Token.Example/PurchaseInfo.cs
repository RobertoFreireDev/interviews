namespace Token.Example
{
    public class PurchaseInfo
    {
        // CreditCard
        public string BRAND { get; set; }
        public string NUMBER { get; set; }
        public string BANK { get; set; }
        public string NAME { get; set; }
        public string CVV { get; set; }
        public string EXPIRY { get; set; }

        // Amount
        public int MONEY { get; set; }
    }   
}
