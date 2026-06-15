using System;

namespace Benchmark.Util
{
    public static class StringUtil
    {
        public static string CreateRandomStringFromChar(string chars, int inputLength)
        {
            var stringChars = new char[inputLength];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
