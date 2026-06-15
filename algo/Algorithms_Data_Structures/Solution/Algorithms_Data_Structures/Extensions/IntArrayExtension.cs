namespace Algorithms_Data_Structures.Extensions
{
    public static class IntArrayExtension
    {
        public static void SwapItems(this int[] input, int index1, int index2)
        {
            var copyOfValueFromIndex1 = input[index1];

            input[index1] = input[index2];
            input[index2] = copyOfValueFromIndex1;
        }
    }
}
