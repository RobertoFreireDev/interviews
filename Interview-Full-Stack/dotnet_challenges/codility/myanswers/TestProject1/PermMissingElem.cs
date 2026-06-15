
namespace TestProject1;

public static class PermMissingElem
{
    public static int Solution(int[] input)
    {
        var newArray = new int[input.Length + 1];

        foreach (int v in input)
        {
            newArray[v-1] = 1;
        }

        for (int i=0; i < newArray.Length; i++)
        {
            if (newArray[i] == 0)
            {
                return i+1;
            }
        }

        return -1;
    }
}
