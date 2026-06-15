namespace TestProject1
{
    public static class OddOccurrencesInArray
    {
        public static int Solution(int[] input)
        {
            var frequencyInput = new Dictionary<int, int>();

            foreach (int i in input)
            {
                if (frequencyInput.TryGetValue(i, out int value))
                {
                    value++;
                    frequencyInput[i] = value;
                }
                else
                {
                    frequencyInput.Add(i, 1);
                }
            }

            foreach (var fI in frequencyInput)
            {
                if (fI.Value == 1)
                {
                    return fI.Key;
                }
            }

            return -1;
        }

        public static int Solution2(int[] input)
        {
            var frequencyInput = new HashSet<int>();

            foreach (int i in input)
            {
                if (frequencyInput.Contains(i))
                {
                    frequencyInput.Remove(i);
                }
                else
                {
                    frequencyInput.Add(i);
                }
            }

            return frequencyInput.FirstOrDefault();
        }
    }
}
