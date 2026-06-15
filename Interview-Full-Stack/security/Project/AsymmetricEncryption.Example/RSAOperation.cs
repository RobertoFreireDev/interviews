using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryption.Example
{
    public static class RSAOperation
    {
        public static byte[] Encrypt(string publicKey, string message)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            var dataToEncrypt = byteConverter.GetBytes(message);

            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {                 
                rsa.FromXmlString(publicKey); // Set the rsa pulic key  
  
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return encryptedData;
        }
        
        public static string Decrypt(string privateKey, byte[] dataToDecrypt)
        { 
            byte[] decryptedData;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            { 
                rsa.FromXmlString(privateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }
            
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetString(decryptedData);
        }
    }
}
