using Algorithms_Data_Structures.Extensions;

namespace Algorithms_Data_Structures.Algorithms.Sort
{
    public static class InsertSort
    {
        public static int[] Sort(int[] input)
        {
            for (int i=1; i < input.Length; i++)
            {
                var insertElement = input[i];
                var insertElementIndex = i;

                for (int j = insertElementIndex - 1; j >= 0; j--)
                {
                    if (insertElement < input[j])
                    {
                        input[j + 1] = input[j];
                        insertElementIndex--;
                    }
                }
                input[insertElementIndex] = insertElement;
            }

            return input;
        }

        public static int[] Sort_Solution2(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                var insertElement = input[i];
                var insertElementIndex = i;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (insertElement < input[j])
                    {
                        input.SwapItems(j, insertElementIndex);
                        insertElementIndex--;
                    }
                }
            }

            return input;
        }
    }
}
