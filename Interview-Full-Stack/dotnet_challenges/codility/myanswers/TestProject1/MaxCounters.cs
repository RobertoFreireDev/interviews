namespace TestProject1;

public static class MaxCounters
{
    public static int[] Solution(int N,int[] input)
    {
        var maxCounter = 0;
        var result = new int[N];
        var baselineRepeatValue = 0;

        foreach (var item in input)
        {
            var index = item - 1;
            if (item <= N)
            {
                if (result[index] < baselineRepeatValue)
                {
                    result[index] = baselineRepeatValue;
                }
                result[index]++;
                maxCounter = Math.Max(maxCounter, result[index]);
            }
            else if (item == N + 1)
            {
                baselineRepeatValue = maxCounter;
            }
        }

        for (int i = 0; i < N; i++)
        {
            if (result[i] < baselineRepeatValue)
            {
                result[i] = baselineRepeatValue;
            }
        }

        return result;
    }
}
