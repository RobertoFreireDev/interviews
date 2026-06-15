using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;
using ClosuresInMultithreading;

namespace Tests
{
    public class ArrayProcessor
    {
        private readonly ITestOutputHelper output;

        public ArrayProcessor(ITestOutputHelper output) 
        {
            this.output = output;
        }

        private int[] GenerateArray()
        {
            return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        }

        private int[] GenerateExpectedArray()
        {
            return new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        }

        [Fact]
        public void MustProcessArray()
        {
            int[] array = GenerateArray();
            int[] expectedArray = GenerateExpectedArray();
            var stopwatch = Stopwatch.StartNew();

            array.Process();

            stopwatch.Stop();
            output.WriteLine(stopwatch.ElapsedMilliseconds.ToString());

            Assert.Equal(expectedArray, array);
        }

        [Fact]
        public void MustProcessArrayInParallel()
        {
            int[] array = GenerateArray();
            int[] expectedArray = GenerateExpectedArray();
            var stopwatch = Stopwatch.StartNew();

            array.ProcessInParallel();

            stopwatch.Stop();
            output.WriteLine(stopwatch.ElapsedMilliseconds.ToString());

            Assert.Equal(expectedArray,array);
        }
    }
}
