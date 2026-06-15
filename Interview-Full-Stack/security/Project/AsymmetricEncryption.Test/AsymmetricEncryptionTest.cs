using AsymmetricEncryption.Example;
using FluentAssertions;
using System.Security.Cryptography;
using Xunit;

namespace AsymmetricEncryption.Test
{
    public class AsymmetricEncryptionTest
    {
        [Fact]
        public void MustEncryptAndDecrypt()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            
            string publicKey = rsa.ToXmlString(false); // false to get the public key   
            string privateKey = rsa.ToXmlString(true); // true to get the private key   

            var str = "string test";

            var encryptedString = RSAOperation.Encrypt(publicKey, str);

            var decryptedString = RSAOperation.Decrypt(privateKey, encryptedString);

            decryptedString.Should().Be(str);
        }
    }
}