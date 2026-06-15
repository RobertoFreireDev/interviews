using BenchmarkDotNet.Attributes;
using Algorithms_Data_Structures;
using Benchmark.Util;

namespace Benchmark.Benchmarks
{
    /*
        |            Method |       Mean |     Error |    StdDev |
        |------------------ |-----------:|----------:|----------:|
        |           Reverse |   212.4 ns |   9.84 ns |  29.00 ns |
        | Reverse_solution2 | 3,546.5 ns | 114.11 ns | 332.85 ns |
    */
    public class ReverseStringBenchmark
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private string input;
        private readonly int inputLength = 100;

        public ReverseStringBenchmark()
        {
            input = StringUtil.CreateRandomStringFromChar(chars, inputLength);
        }

        [Benchmark]
        public string Reverse() => ReverseString.Reverse(input);

        [Benchmark]
        public string Reverse_solution2() => ReverseString.Reverse_solution2(input);
    }
}
