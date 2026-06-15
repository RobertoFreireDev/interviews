namespace TestProject1
{
    public class CyclicRotationTests
    {
        [Theory]
        [InlineData(new int[] { 3, 8, 9, 7, 6 }, 3, new int[] { 9, 7, 6, 3, 8 })]
        [InlineData(new int[] { 0, 0, 0 }, 1, new int[] { 0, 0, 0 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, 0, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, 1, new int[] { 4, 1, 2, 3 })]
        [InlineData(new int[] { }, 3, new int[] { })] // Test with empty array
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })] // Single element array
        [InlineData(new int[] { 1, 2, 3, 4 }, 5, new int[] { 4, 1, 2, 3 })] // K > N
        [InlineData(new int[] { 1, 2, 3, 4 }, 8, new int[] { 1, 2, 3, 4 })] // K is a multiple of N
        [InlineData(new int[] { 1, 2, 3, 4 }, 9, new int[] { 4, 1, 2, 3 })] // K is more than a multiple of N
        public void Test1(int[] input, int K, int[] expected)
        {
            // Act
            var result = CyclicRotation.Solution(input, K);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
