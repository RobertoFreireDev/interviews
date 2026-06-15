namespace Algorithms_Data_Structures.Algorithms.TwoPointers;

public static class TwoPointers
{
    // Given a sorted array A(sorted in ascending order), having N integers,
    // find if there exists any pair of elements(A[i], A[j]) such that their sum is equal to X.

    public static bool FindIndexOfPairSum(int[] array, int targetSum)
    {
        var leftPointer = 0;
        var rightPointer = array.Length - 1;
        var sum = 0;

        do
        {
            sum = array[leftPointer] + array[rightPointer];
            if (sum == targetSum)
            {
                return true;
            }
            
            if (sum > targetSum)
            {
                rightPointer--;
                continue;
            }
            else if (sum < targetSum)
            {
                leftPointer++;
                continue;
            }
        } while (leftPointer < rightPointer);

        return false;
    }
}