namespace tests.Extension
{
    public static class IntExtension
    {
        public static string CreateString(this int[] input)
        {
            if (input.Length <= 0)
            { 
                return string.Empty;
            }

            var result = input[0].ToString();

            for (int i = 1; i < input.Length; i++)
            {
                result = result + ", " + input[i].ToString();
            }

            return result;
        }
    }
}
