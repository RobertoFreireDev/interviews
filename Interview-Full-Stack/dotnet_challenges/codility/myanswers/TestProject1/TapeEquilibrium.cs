namespace TestProject1;

public static class TapeEquilibrium
{
    public static int Solution(int[] input)
    {
        var lentgh = input.Length;
        var part1 = input[0];
        var part2 = 0;

        for (int i = 1; i < lentgh; i++)
        {
            part2 += input[i];
        }

        var result = Math.Abs(part1 - part2);

        for (int i = 1; i < lentgh -1; i++)
        {
            part1 += input[i];
            part2 -= input[i];

            result = Math.Min(result, Math.Abs(part1 - part2));
        }

        return result;
    }
}