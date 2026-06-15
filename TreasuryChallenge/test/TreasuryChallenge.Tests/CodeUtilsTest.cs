using Xunit;
using TreasuryChallenge.utils;
using System.Linq;

namespace TreasuryChallenge
{
    public class CodeUtilsTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        public void MustReturnCodeWithSameLengthAsInputed(int lengthContent)
        {
            string result = CodeUtils.Generate(lengthContent);

            Assert.Equal(lengthContent, result.Length);
        }

        [Fact]
        public void MustResultBeOnlyCharacters()
        {
            int lengthContent = 10;
            string LETTERS_OF_THE_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string result = CodeUtils.Generate(lengthContent);

            foreach (char r in result.ToCharArray(0, result.Length))
            {
                Assert.True(LETTERS_OF_THE_ALPHABET.Contains(r));
            }
        }

        [Fact]
        public void MustNotHaveDuplicatedCharacters()
        {
            int lengthContent = 10;

            string result = CodeUtils.Generate(lengthContent);

            Assert.True(result.Distinct().Count() == result.Length);
        }
    }
}
