using Algorithms_Data_Structures.Algorithms.SortByFrequency;
using tests.Extension;
using Xunit;

namespace tests.Algorithms
{
    public class SortByFrequencyTest
    {
        [Theory]
        [InlineData("2, 5, 2, 8, 5, 6, 8, 8", "8, 8, 8, 2, 2, 5, 5, 6")]
        [InlineData("5, 2, 2, 8, 5, 6, 8, 8", "8, 8, 8, 5, 5, 2, 2, 6")]
        [InlineData("2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8", "8, 8, 8, 2, 2, 5, 5, 6, -1, 9999999")]
        [InlineData("2, 3, 2, 4, 5, 12, 2, 3, 3, 3, 12", "3, 3, 3, 3, 2, 2, 2, 12, 12, 4, 5")]
        [InlineData("3", "3")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        public void Sort(string array, string expectedOutput)
        {
            var result = SortByFrequency.Sort(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }

        [Theory]
        [InlineData("cccaaa", "aaaccc", "cccaaa")]
        [InlineData("tree", "eert", "eetr")]
        [InlineData("Aabb", "bbAa", "bbaA")]
        public void SortString(string array, string expectedOutput, string expectedOutput2)
        {
            var result = SortStringByFrequency.Sort(array);

            Assert.True(expectedOutput == result || expectedOutput2 == result);
        }
    }
}
