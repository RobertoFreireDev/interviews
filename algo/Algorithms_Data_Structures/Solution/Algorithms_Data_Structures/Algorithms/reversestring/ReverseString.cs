namespace Algorithms_Data_Structures
{
    public static class ReverseString
    {
        public static string Reverse(string input) {
            char[] inputAsCharArray = input.ToCharArray();
            int inputAsCharArrayLength = inputAsCharArray.Length;
            char[] outputAsCharArray = new char[inputAsCharArrayLength];
            int j = 0;

            for (int i = inputAsCharArrayLength - 1; i >= 0; --i)
            {
                outputAsCharArray[j] = inputAsCharArray[i];
                j++;
            }
            return new string(outputAsCharArray);
        }

        public static string Reverse_solution2(string input)
        {
            string output = "";

            foreach (char character in input)
            {
                output = character + output;
            }
            return output;
        }
    }
}
