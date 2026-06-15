namespace TestProject1;

public class MaxCountersTests
{
    [Theory]
    [InlineData(new int[] { 3, 4, 4, 6, 1, 4, 4 }, 5, new int[] { 3, 2, 2, 4, 2 })] // Example given
    [InlineData(new int[] { 1 }, 1, new int[] { 1 })] // Single element array
    [InlineData(new int[] { 1, 1, 1, 1 }, 1, new int[] { 4 })] // All operations are increase(1)
    [InlineData(new int[] { 6, 6, 6, 6 }, 5, new int[] { 0, 0, 0, 0, 0 })] // All operations are max counter
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 1, 1, 1, 1 })] // All operations are increase(X), X is consecutive
    [InlineData(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5 }, 5, new int[] { 4, 4, 4, 4, 5 })] // All operations are increase(X), X is 6
    [InlineData(new int[] { 1, 1, 1, 1, 6 }, 5, new int[] { 4, 4, 4, 4, 4 })] // Last operation is max counter
    [InlineData(new int[] { 6, 6, 1, 1, 1 }, 5, new int[] { 3, 0, 0, 0, 0 })] // First operation is max counter
    [InlineData(new int[] { 6, 6, 1, 1, 1, 6, 6 }, 5, new int[] { 3, 3, 3, 3, 3 })] // First and last operations are max counter
    [InlineData(new int[] { 1, 1, 6, 6, 1, 1, 6, 6 }, 5, new int[] { 4, 4, 4, 4, 4 })] // Multiple max counter operations interleaved
    [InlineData(new int[] { 1, 6, 1, 1, 6, 1, 1 }, 5, new int[] { 5, 3, 3, 3, 3 })] 
    [InlineData(new int[] { 6, 6, 6, 1, 1, 1 }, 5, new int[] { 3, 0, 0, 0, 0 })] // Multiple max counter operations interleaved at the beginning
    [InlineData(new int[] { 1, 1, 1, 6, 6, 6 }, 5, new int[] { 3, 3, 3, 3, 3 })] // Multiple max counter operations interleaved at the end
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 5, new int[] { 1, 1, 1, 1, 1 })] // Increase(X) operations only
    [InlineData(new int[] { 6, 6, 6, 6, 6, 6 }, 5, new int[] { 0, 0, 0, 0, 0 })] // All max counter operations
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1 }, 5, new int[] { 6, 0, 0, 0, 0 })] // All operations are increase(1), then max counter
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 5, new int[] { 7, 0, 0, 0, 0 })] // All operations are increase(1), then max counter
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 6 }, 5, new int[] { 6, 6, 6, 6, 6 })] // All operations are increase(1), then max counter with different values
    [InlineData(new int[] { 1, 2, 3, 4, 6, 6, 6 }, 5, new int[] { 1, 1, 1, 1, 1 })] // Some increase(X) and some max counter operations
    public void Test1(int[] input, int N, int[] expected)
    {
        // Act
        var result = MaxCounters.Solution(N, input);

        // Assert
        Assert.Equal(expected, result);
    }
}
