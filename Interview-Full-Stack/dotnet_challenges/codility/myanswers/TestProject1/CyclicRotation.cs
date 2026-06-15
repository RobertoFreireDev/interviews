namespace TestProject1;
public static class CyclicRotation
{
    public static int[] Solution(int[] A, int K)
    {
        var aLength = A.Length;

        if (aLength == 0)
        {
            return A;
        }

        var j = K % aLength;

        if (j == 0)
        {
            return A;
        }

        var result = new int[aLength];

        for (int i = 0; i < aLength - j; i++)
        {
            result[i+j]=A[i];
        }

        var constI = aLength - j;
        for (int i = aLength - j; i < aLength; i++)
        {
            result[i - constI] = A[i];
        }

        return result;
    }
}