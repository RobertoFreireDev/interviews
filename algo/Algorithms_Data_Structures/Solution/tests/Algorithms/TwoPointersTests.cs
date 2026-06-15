using Algorithms_Data_Structures.Algorithms.TwoPointers;
using Xunit;

namespace tests.Algorithms;

public class TwoPointersTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 6, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 30, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 0, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, -6, false)]
    [InlineData(new int[] { 10, 20, 30, 40, 60 }, 33, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 6, 4, 2, 6 }, 10, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 7, true)]
    [InlineData(new int[] { -3, -1, 0, 2, 4, 5 }, 1, true)]
    [InlineData(new int[] { -3, -1, 0, 2, 4, 5 }, -4, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 6 }, 12, false)] // No pair found
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 15, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 17, true)]
    [InlineData(new int[] { -10, -5, 0, 5, 10, 15, 20 }, 5, true)]
    [InlineData(new int[] { -10, -5, 0, 5, 10, 15, 20 }, 25, true)]
    [InlineData(new int[] { -10, -5, 0, 5, 10, 15, 20 }, 30, true)] // No pair found
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 2, true)] // Multiple same elements
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 3, false)] // Multiple same elements, no valid pair
    public void MustFindIndexesOfFirstPairSum(int[] array, int targetSum, bool expectedResult)
    {
        var result = TwoPointers.FindIndexOfPairSum(array, targetSum);
        Assert.Equal(expectedResult, result);
    }
}