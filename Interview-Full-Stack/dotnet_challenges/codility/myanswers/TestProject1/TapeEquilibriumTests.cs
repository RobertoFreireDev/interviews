namespace TestProject1
{
    public class TapeEquilibriumTests
    {
        [Theory]
        [InlineData(new int[] { 3, 1, 2, 4, 3 }, 1)] // Standard case
        [InlineData(new int[] { 1, 1 }, 0)] // Minimum size array
        [InlineData(new int[] { -1000, 1000 }, 2000)] // High difference in two elements
        [InlineData(new int[] { -10, -20, -30, -40, -50 }, 30)] // All negative numbers
        [InlineData(new int[] { 10, -10, 10, -10, 10, -10 }, 0)] // Alternating positive and negative numbers
        [InlineData(new int[] { 1000, 1000, 1000, 1000, 1000 }, 1000)] // All same numbers, high value
        [InlineData(new int[] { -3, -1, -2, -4, -3 }, 1)] // Negative numbers with minimal difference
        [InlineData(new int[] { 3, 3, 3, 3, 3 }, 3)] // All same numbers
        [InlineData(new int[] { 0, 0, 0, 0, 0 }, 0)] // All zeros
        [InlineData(new int[] { 1, -1, 1, -1, 1, -1, 1 }, 1)] // Alternating 1 and -1
        [InlineData(new int[] { 1, -1, 1, -1, 1, -1 }, 0)] // Alternating 1 and -1
        public void Test1(int[] input, int expected)
        {
            // Act
            var result = TapeEquilibrium.Solution(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
