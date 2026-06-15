using System;
using TreasuryChallenge.Common;

namespace TreasuryChallenge.utils
{
    public static class CodeUtils
    {
        public static String Generate(int lengthContent)
        {
            String response = Constants.EMPTY_STRING;
            int numberOfChars = Constants.LETTERS_OF_THE_ALPHABET.Length;
            bool[] used = new bool[numberOfChars];
            char[] chars = Constants.LETTERS_OF_THE_ALPHABET.ToCharArray(0, numberOfChars);
            Random random = new Random();

            while (response.Length < lengthContent)
            {
                int letterPosition = random.Next(numberOfChars - 1);
                if (!used[letterPosition])
                {
                    used[letterPosition] = true;
                    response += chars[letterPosition];
                }
            }

            return response;
        }
    }
}