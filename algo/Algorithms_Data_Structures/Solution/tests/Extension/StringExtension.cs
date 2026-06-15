namespace tests.Extension
{
    public static class StringExtension
    {
        public static int[] CreateIntArray(this string input)
        {
            var stringArray = input.Split(",");

            var intArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i ++)
            {
                var isNotValidInt = !int.TryParse(stringArray[i], out int result);

                if (isNotValidInt)
                {
                    return new int[0];
                }

                intArray[i] = result;
            }

            return intArray;
        }
    }
}
