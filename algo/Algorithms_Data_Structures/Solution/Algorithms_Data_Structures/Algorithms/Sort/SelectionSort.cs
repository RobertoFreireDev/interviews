using System.Collections.Generic;

namespace Algorithms_Data_Structures.Algorithms.Sort
{
    public class Item
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }

    public static class SelectionSort
    {
        public static Item[] Sort(Item[] input)
        {
            for (var currentPosition = 0; currentPosition < input.Length - 1; currentPosition++)
            {
                var currentMinValueIndex = currentPosition;

                for (int i = currentPosition + 1; i < input.Length; i++)
                {
                    if (input[i].Value < input[currentMinValueIndex].Value)
                    {
                        currentMinValueIndex = i;
                    }
                }

                var currentMinValue = input[currentMinValueIndex];
                input[currentMinValueIndex] = input[currentPosition];
                input[currentPosition] = currentMinValue;
            }

            return input;
        }

        public static int[] Sort(int[] input)
        {
            for (var currentPosition = 0; currentPosition < input.Length - 1; currentPosition++)
            {
                var currentMinValueIndex = currentPosition;

                for (int i = currentPosition + 1; i < input.Length; i++)
                {
                    if (input[i] < input[currentMinValueIndex])
                    {
                        currentMinValueIndex = i;
                    }
                }

                var currentMinValue = input[currentMinValueIndex];
                input[currentMinValueIndex] = input[currentPosition];
                input[currentPosition] = currentMinValue;
            }

            return input;
        }

        public static int[] Sort_Solution2(int[] input)
        {
            for (var currentPosition = 0; currentPosition < input.Length - 1; currentPosition++)
            {
                var currentIndex = currentPosition;
                var currentMinValue = input[currentIndex];

                for (int i = currentPosition + 1; i < input.Length; i++)
                {
                    if (input[i] < currentMinValue)
                    {
                        currentMinValue = input[i];
                        currentIndex = i;
                    }
                }

                input[currentIndex] = input[currentPosition];
                input[currentPosition] = currentMinValue;
            }

            return input;
        }

        public static int[] Sort_Solution3(int[] input)
        {
            var inputAsList = new List<int>(input);
            var inputLength = input.Length;
            var result = new int[inputLength];
            var currentPosition = 0;            

            while (currentPosition < inputLength)
            {
                var currentIndex = 0;
                var currentMinValue = inputAsList[currentIndex];                

                for (int i = 1; i < inputAsList.Count; i++)
                {
                    if (inputAsList[i] < currentMinValue)
                    {
                        currentMinValue = inputAsList[i];
                        currentIndex = i;
                    }
                }

                result[currentPosition] = currentMinValue;
                inputAsList.RemoveAt(currentIndex);
                currentPosition++;
            }            

            return result;
        }
    }
}
