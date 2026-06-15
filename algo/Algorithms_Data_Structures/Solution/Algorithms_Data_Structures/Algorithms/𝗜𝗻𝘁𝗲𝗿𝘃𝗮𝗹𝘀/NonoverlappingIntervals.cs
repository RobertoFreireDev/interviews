using System;

namespace Algorithms_Data_Structures.Algorithms;

public static class NonoverlappingIntervals
{
    public static int Solution(int[][] intervals)
    {
        var result = 0;
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
        int[] prevPointer = intervals[0];

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] currPointer = intervals[i];
            if (IsOverlapping(prevPointer, currPointer))
            {
                result++;
                if (prevPointer[1] >= currPointer[1])
                {
                    prevPointer = currPointer;
                }
            }
            else
            {
                prevPointer = currPointer;
            }
        }

        return result;
    }

    private static bool IsOverlapping(int[] a, int[]b)
    {
        return b[0] < a[1];
    }
}