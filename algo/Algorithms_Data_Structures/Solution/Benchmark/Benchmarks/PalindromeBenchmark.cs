using Algorithms_Data_Structures;
using Benchmark.Util;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    /*
       |                  Method |     Mean |    Error |   StdDev |
       |------------------------ |---------:|---------:|---------:|
       |           IsAPalindrome | 41.06 ns | 0.645 ns | 0.539 ns |
       | IsAPalindrome_solution2 | 18.64 ns | 0.410 ns | 1.051 ns |
    */
    public class PalindromeBenchmark
    {
        private const string chars = "AB";
        private string input;
        private readonly int inputLength = 4;

        public PalindromeBenchmark()
        {
            input = StringUtil.CreateRandomStringFromChar(chars, inputLength);
        }

        [Benchmark]
        public bool IsAPalindrome() => Palindrome.IsAPalindrome(input);

        [Benchmark]
        public bool IsAPalindrome_solution2() => Palindrome.IsAPalindrome_solution2(input);
    }
}
