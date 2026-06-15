namespace TestProject1;

public class PermMissingElemTests
{
    [Theory]
    [InlineData(new int[] { 2, 3, 1, 5 }, 4)] // Example given
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 5)] // Missing element in the middle
    [InlineData(new int[] { 2, 3, 4, 5, 6 }, 1)] // Missing first element
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6)] // Missing last element
    [InlineData(new int[] { }, 1)] // Empty array case
    [InlineData(new int[] { 2 }, 1)] // Single element missing
    [InlineData(new int[] { 1 }, 2)] // Single element present
    [InlineData(new int[] { 1, 3, 4, 5 }, 2)] // Missing element at the beginning
    [InlineData(new int[] { 1, 2, 3, 5 }, 4)] // Missing element in the middle
    [InlineData(new int[] { 1, 2, 4, 5 }, 3)] // Missing element in the middle
    public void Test1(int[] input, int expected)
    {
        var result = PermMissingElem.Solution(input);

        // Assert
        Assert.Equal(expected, result);
    }
}