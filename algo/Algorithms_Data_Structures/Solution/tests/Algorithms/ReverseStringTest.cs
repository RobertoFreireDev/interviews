using Algorithms_Data_Structures;
using Xunit;

namespace tests.Algorithms
{
    public class ReverseStringTest
    {
        [Theory]
        [InlineData("abcd","dcba")]
        [InlineData("  abcd", "dcba  ")]
        public void MustReversesAString(string input, string expectedOutput)
        {
            string result = ReverseString.Reverse(input);
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("abcd", "dcba")]
        [InlineData("  abcd", "dcba  ")]
        public void MustSolution2ReversesAString(string input, string expectedOutput)
        {
            string result = ReverseString.Reverse_solution2(input);
            Assert.Equal(expectedOutput, result);
        }
    }
}