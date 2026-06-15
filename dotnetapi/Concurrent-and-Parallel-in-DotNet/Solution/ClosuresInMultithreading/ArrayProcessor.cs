using System.Threading;
using System.Threading.Tasks;

namespace ClosuresInMultithreading
{
    public static class ArrayProcessor
    {
        public static void ProcessInParallel(this int[] array)
        {
            Parallel.Invoke(
            () => AddOneToEachItem(array, 0, array.Length / 2),
            () => AddOneToEachItem(array, array.Length / 2, array.Length));
        }

        public static void Process(this int[] array)
        {
            AddOneToEachItem(array, 0, array.Length);
        }

        private static void AddOneToEachItem(int[] array, int begin, int end)
        {            
            for (int i = begin; i< end; i++)
            {
                Thread.Sleep(10);
                array[i] = array[i] + 1;
            }
        }
    }
}
