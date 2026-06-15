using System.Collections.Generic;
using Algorithms_Data_Structures.Extensions;

namespace Algorithms_Data_Structures.Algorithms.SortByFrequency
{
    public static class SortByFrequency
    {
        public class ItemFrequency
        {
            public int Frequency { get; set; }
            public int Index { get; set; }

            public ItemFrequency(int frequency, int index)
            {
                Frequency = frequency;
                Index = index;
            }
        }

        public static int[] Sort(int[] input) //2, 5, 2, 8, 5, 6, 8, 8
        {
            var lentgh = input.Length;
            var copy = input.CreateCopyIntArray();

            // sort
            //2, 2, 5, 5, 6, 8, 8, 8
            var sortedInput = input.SortIntArray();

            // create list of frequency
            //2, 2
            //5, 2
            //6, 1
            //8, 3
            var listFrequency = CreateListFrequency(sortedInput, copy, lentgh);

            // sort list of frequency by frequency. It must maitain order in case of same frequency
            //8, 3
            //2, 2
            //5, 2
            //6, 1
            listFrequency.SortListByFrequency();

            // Create new array
            //8, 8, 8, 2, 2, 5, 5, 6
            return CreateResult(listFrequency, copy, lentgh);
        }

        private static List<ItemFrequency> CreateListFrequency(int[] sortedInput, int[] copy, int lentgh)
        {
            var listFrequency = new List<ItemFrequency>();
            var value = sortedInput[0];
            var frequency = 1;

            for (int i = 1; i < lentgh; i++)
            {
                if (value != sortedInput[i])
                {
                    listFrequency.Add(new ItemFrequency(frequency, copy.GetIndexValue(value)));
                    value = sortedInput[i];
                    frequency = 1;
                }
                else
                {
                    frequency++;
                }
            }
            listFrequency.Add(new ItemFrequency(frequency, copy.GetIndexValue(value)));

            return listFrequency;
        }

        private static int[] CreateResult(List<ItemFrequency> listFrequency, int[] copy, int lentgh)
        {
            var result = new int[lentgh];
            var resultIndex = 0;

            foreach (var itemFrequency in listFrequency)
            {
                for (int i = 0; i < itemFrequency.Frequency; i++)
                {
                    result[resultIndex] = copy[itemFrequency.Index];
                    resultIndex++;
                }
            }

            return result;
        }

        public static int GetIndexValue(this int[] input, int value)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int[] SortIntArray(this int[] input)
        {
            var length = input.Length;
            bool didSwap;

            do
            {
                didSwap = false;

                for (var i = 0; i < length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        input.SwapItems(i, i + 1);
                        didSwap = true;
                    }
                }
            } while (didSwap);

            return input;
        }

        public static int[] CreateCopyIntArray(this int[] input)
        {
            var length = input.Length;
            var copy = new int[length];

            for (int i = 0; i < length; i++)
            {
                copy[i] = input[i];
            }

            return copy;
        }

        public static void SortListByFrequency(this List<ItemFrequency> input)
        {
            var length = input.Count;
            bool didSwap;

            do
            {
                didSwap = false;

                for (var i = 0; i < length - 1; i++)
                {
                    if (input[i].Frequency < input[i + 1].Frequency)
                    {
                        input.SwapItems(i, i + 1);
                        didSwap = true;
                    }
                    else if (input[i].Frequency == input[i + 1].Frequency &&
                        input[i].Index > input[i + 1].Index)
                    {
                        input.SwapItems(i, i + 1);
                        didSwap = true;
                    }
                }
            } while (didSwap);
        }

        public static void SwapItems(this List<ItemFrequency> input, int index1, int index2)
        {
            var temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }
    }
}
