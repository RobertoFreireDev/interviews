using FluentAssertions;
using SymmetricEncryption.Example;
using Xunit;

namespace SymmetricEncryption.Test
{
    public class SymmetricEncryptionTest
    {
        [Fact]
        public void MustEncryptAndDecrypt()
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var str = "string test";

            var encryptedString = AesOperation.EncryptString(key, str);

            var decryptedString = AesOperation.DecryptString(key, encryptedString);

            decryptedString.Should().Be(str);
        }
    }
}