namespace Algorithms_Data_Structures.BigONotation
{
    public static class BigONotation
    {
        // O(1) time
        public static int AccessingArrayIndex(int[] array, int index)
        {
            return array[index];
        }

        // O(n) time
        public static bool IsEqual(this string text1, string text2)
        {
            if (text1.Length != text2.Length)
            {
                return false;
            }

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    return false;
                }
            }

            return true;
        }

        // O(log n) time
        public static int BinarySearchMain(int[] sortedArray, int value)
        {
            return BinarySearchRecursive(sortedArray, value, 0, sortedArray.Length -1);
        }

        private static int BinarySearchRecursive(int[] sortedArray, int value, int begin, int end)
        {
            int mid = (end - begin)/2 + begin;

            if (begin > end)
            {
                return -1;
            }

            if (value < sortedArray[mid])
            {
                return BinarySearchRecursive(sortedArray, value, begin, mid - 1);
            }
            else if (value > sortedArray[mid])
            {
                return BinarySearchRecursive(sortedArray, value, mid + 1, end);
            }
            else
            {
                if (mid > 0 && value == sortedArray[mid-1])
                {
                    return BinarySearchRecursive(sortedArray, value, mid - 1, mid - 1);
                }
                return mid;
            }
        }
    }
}
