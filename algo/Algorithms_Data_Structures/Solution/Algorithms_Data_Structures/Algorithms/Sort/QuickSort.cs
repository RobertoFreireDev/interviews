using Algorithms_Data_Structures.Extensions;

namespace Algorithms_Data_Structures.Algorithms.Sort
{
    public static class QuickSort
    {
        public static int[] Sort(int[] input)
        {
            QuickSort(input, 0, input.Length - 1);            

            return input;

            void QuickSort(int[] input, int minIndex, int maxIndex)
            {
                var inputLength = maxIndex - minIndex + 1;

                if (inputLength <= 1)
                {
                    return;
                }
                else if (inputLength == 2)
                {
                    if (input[minIndex] > input[maxIndex])
                    {
                        input.SwapItems(minIndex, maxIndex);
                    }

                    return;
                }

                var pivotIndex = SetPivot(input, minIndex, maxIndex, inputLength);

                var leftCursor = minIndex;
                var rightCursor = maxIndex;
                var done = false;

                while (!done)
                {
                    var movedCursor = false;

                    if ((leftCursor + 1) != pivotIndex &&
                        input[pivotIndex] >= input[leftCursor + 1])
                    {
                        movedCursor = true;
                        leftCursor ++;
                    }

                    if ((rightCursor - 1) != pivotIndex &&
                        input[pivotIndex] <= input[rightCursor - 1])
                    {
                        movedCursor = true;
                        rightCursor--;
                    }

                    if (leftCursor + 1 == pivotIndex &&
                        rightCursor - 1 == pivotIndex)

                    {
                        done = true;
                    }

                    if (!movedCursor)
                    {
                        if (leftCursor + 1 == pivotIndex)
                        {
                            pivotIndex = rightCursor - 1;
                        } else if (rightCursor - 1 == pivotIndex)
                        {
                            pivotIndex = leftCursor + 1;
                        }

                        input.SwapItems(leftCursor + 1, rightCursor - 1);
                    }
                }

                QuickSort(input, minIndex, pivotIndex - 1);
                QuickSort(input, pivotIndex + 1, maxIndex);
            }

            int GetMiddleValue(int number)
            {
                return number % 2 == 0 ? number/2 : (number + 1)/2;
            }

            int SetPivot(int[] input, int minIndex, int maxIndex, int inputLength)
            {
                var middleIndex = GetMiddleValue(inputLength) - 1 + minIndex;

                var items = new Item[]
                {
                    new Item { Value = input[minIndex], Index = minIndex},
                    new Item { Value = input[middleIndex], Index = middleIndex},
                    new Item { Value = input[maxIndex], Index = maxIndex}
                };

                var sortedItems = SelectionSort.Sort(items);

                input[minIndex] = sortedItems[0].Value;
                input[middleIndex] = sortedItems[1].Value;
                input[maxIndex] = sortedItems[2].Value;

                return middleIndex;
            }
        }
    }
}
