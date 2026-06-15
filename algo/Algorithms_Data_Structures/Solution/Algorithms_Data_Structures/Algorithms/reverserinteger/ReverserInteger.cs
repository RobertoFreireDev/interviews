namespace Algorithms_Data_Structures.Algorithms.reverserinteger;

public class ReverserInteger
{
    public static string Reverse(int N)
    {
        var result = string.Empty;
        var isZero= N % 10 == 0;
        while (N != 0) {
            if (isZero)
            {
                N = N / 10;
                isZero = N % 10 == 0;
            }
            else
            {
                result += N % 10;
                N = N / 10;
            }
        }
        return result;
    }

    public static string Reverse2(int N)
    {
        //1
        var result = string.Empty;
        var enable_print = false;
        while (N > 0)
        {
            if (enable_print == false && N % 10 != 0)
            {
                enable_print = true;
            }

            if (enable_print)
            {
                result += N % 10;
            }
            N = N / 10;
        }

        return result;
    }
}
