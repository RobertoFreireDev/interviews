using System;

namespace Algorithms_Data_Structures
{
    public static class Palindrome
    {
        public static bool IsAPalindrome(string input)
        {
            string result = ReverseString.Reverse(input);
            return String.Equals(result, input);
        }

        public static bool IsAPalindrome_solution2(string input)
        {
            char[] inputAsCharArray = input.ToCharArray();
            int inputAsCharArrayLength = inputAsCharArray.Length;
            int middleNumber;
            bool isValidLength = TryGetMiddleNumber(inputAsCharArrayLength, out middleNumber);
            if (!isValidLength) return false;

            int j = 0;

            for (int i = inputAsCharArrayLength - 1; i >= 0; --i)
            {
                if (j == middleNumber) return true;
                if (inputAsCharArray[i] != inputAsCharArray[j]) return false;
                j++;
            }
            return true;
        }

        private static bool TryGetMiddleNumber(int number, out int middleNumber) {
            int numberDividedByTwo = number / 2;
            middleNumber = number % 2 == 0 ? numberDividedByTwo : numberDividedByTwo - 1;

            return (number > 0);
        }
    }
}
