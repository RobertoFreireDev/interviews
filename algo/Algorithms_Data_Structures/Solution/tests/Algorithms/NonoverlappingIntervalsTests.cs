using Algorithms_Data_Structures.Algorithms;
using System.Collections.Generic;
using Xunit;

namespace tests.Algorithms;

public class NonoverlappingIntervalsTests
{
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] {
            new int[][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 1, 3 }
            }, 1 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 1, 2 }
            }, 1 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 2 },
                new int[] { 1, 2 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 }
            }, 0 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 100 },
                new int[] { 11, 22 },
                new int[] { 1, 11 },
                new int[] { 2, 12 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 100 },
                new int[] { 1, 11 },
                new int[] { 2, 12 },
                new int[] { 11, 22 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 11, 22 },
                new int[] { 1, 11 },
                new int[] { 2, 12 },
                new int[] { 1, 100 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 11, 22 },
                new int[] { 2, 12 },
                new int[] { 1, 100 },
                new int[] { 1, 11 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 11 },
                new int[] { 2, 12 },
                new int[] { 11, 22 },
                new int[] { 1, 100 }
            }, 2 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 5 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 }
            }, 1 };

        yield return new object[] {
            new int[][] {
                new int[] { -50, -25 },
                new int[] { -30, -20 },
                new int[] { -25, 0 }
            }, 1 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 10 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 5, 6 }
            }, 1 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 2 }
            }, 0 };

        yield return new object[] {
            new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 1, 4 },
                new int[] { 1, 5 }
            }, 3 };
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void EraseOverlapIntervalsTests(int[][] intervals, int expected)
    {
        var result = NonoverlappingIntervals.Solution(intervals);

        Assert.Equal(expected, result);
    }
}
