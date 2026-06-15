using System.Security.Cryptography;
using System.Text;

namespace Hash.Example
{
    public class SecretMessage
    {
        private byte[] Hash { get; set; }

        private byte[] Salt { get; set; }

        public void Set(string message)
        {
            using (var hmac = new HMACSHA512())
            {
                Salt = hmac.Key;
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            }
        }

        public bool Verify(string message)
        {
            using (var hmac = new HMACSHA512(Salt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return computedHash.SequenceEqual(Hash);
            }
        }
    }
}
