using Algorithms_Data_Structures.Algorithms.Substring;
using Xunit;

namespace tests.Algorithms
{
    public class MinimumWindowSubstringTest
    {
        [Theory]
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("BANCADOBECODE", "ABC", "BANC")]
        [InlineData("a", "a", "a")]
        [InlineData("a", "aa", "")]
        public void MustMinimumWindowSubstring(string s, string t, string expectedOutput)
        {
            var result = MinimumWindowSubstring.MinWindow(s,t);
            Assert.Equal(expectedOutput, result);
        }
    }
}
