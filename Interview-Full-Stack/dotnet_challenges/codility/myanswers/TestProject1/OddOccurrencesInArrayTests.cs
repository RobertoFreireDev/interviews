namespace TestProject1
{
    public class OddOccurrencesInArrayTests
    {
        [Theory]
        [InlineData(new int[] { 9, 3, 9, 3, 9, 7, 9 }, 7)]
        [InlineData(new int[] { 1, 2, 3, 1, 2 }, 3)]
        [InlineData(new int[] { 4, 4, 5, 6, 6 }, 5)]
        [InlineData(new int[] { 8, 8, 8, 8, 9 }, 9)]
        [InlineData(new int[] { 10 }, 10)]
        public void Solution1(int[] input, int expected)
        {
            var result = OddOccurrencesInArray.Solution(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 9, 3, 9, 3, 9, 7, 9 }, 7)]
        [InlineData(new int[] { 1, 2, 3, 1, 2 }, 3)]
        [InlineData(new int[] { 4, 4, 5, 6, 6 }, 5)]
        [InlineData(new int[] { 8, 8, 8, 8, 9 }, 9)]
        [InlineData(new int[] { 10 }, 10)]
        public void Solution2(int[] input, int expected)
        {
            var result = OddOccurrencesInArray.Solution2(input);
            Assert.Equal(expected, result);
        }
    }
}