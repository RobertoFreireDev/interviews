using Algorithms_Data_Structures;
using Xunit;

namespace tests.Algorithms
{
    public class PalindromeTest
    {
        [Theory]
        [InlineData("aba")]
        [InlineData("1000000001")]
        [InlineData("pennep")]
        public void MustBeAPalindrome(string input)
        {
            bool result = Palindrome.IsAPalindrome(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData(" aba")]
        [InlineData("aba ")]
        [InlineData("greetings")]
        [InlineData("Fish hsif")]
        public void MustNotBeAPalindrome(string input)
        {
            bool result = Palindrome.IsAPalindrome(input);
            Assert.False(result);
        }

        [Theory]
        [InlineData("aba")]
        [InlineData("1000000001")]
        [InlineData("pennep")]
        public void MustBeAPalindromeForSolution2(string input)
        {
            bool result = Palindrome.IsAPalindrome_solution2(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData(" aba")]
        [InlineData("aba ")]
        [InlineData("greetings")]
        [InlineData("Fish hsif")]
        public void MustNotBeAPalindromeForSolution2(string input)
        {
            bool result = Palindrome.IsAPalindrome_solution2(input);
            Assert.False(result);
        }
    }
}
