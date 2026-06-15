using Algorithms_Data_Structures.BigONotation;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    /*
    */
    public class BigONotationBenchmark
    {
        private int[] simpleInput = new int[] { 10, 64, 80, 30, 70, 25, 25, 12 };

        private int[] complexInput = new int[] {
            10, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 90, 25, 12, 43, 11, 34,
            13, 64, 80, 35, 70, 25, 25, 12, 22, 11, 25, 45, 70, 84, 25, 12, 43, 11, 34,
            56, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 13, 25, 12, 43, 11, 53,
            23, 64, 80, 24, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 24, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            13, 64, 12, 30, 34, 25, 25, 12, 22, 11, 68, 45, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 35, 70, 25, 25, 12, 22, 11, 46, 45, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 30, 70, 25, 25, 12, 22, 18, 25, 45, 70, 23, 25, 12, 43, 11, 34,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 75, 45, 70, 95, 25, 12, 43, 11, 34,
            13, 64, 80, 30, 70, 25, 25, 12, 22, 11, 75, 45, 70, 84, 25, 12, 43, 11, 34,
            56, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 13, 25, 12, 43, 11, 53,
            23, 64, 80, 23, 70, 25, 25, 12, 22, 57, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            13, 64, 12, 46, 34, 25, 25, 12, 22, 11, 46, 46, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 30, 70, 25, 25, 12, 22, 11, 25, 45, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 34, 70, 25, 25, 12, 22, 18, 25, 34, 70, 23, 25, 12, 43, 11, 34,
            13, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 84, 25, 12, 43, 11, 34,
            56, 64, 80, 46, 70, 25, 25, 12, 22, 11, 25, 45, 70, 13, 25, 12, 43, 11, 53,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 23, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            13, 64, 12, 85, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 30, 70, 25, 25, 12, 22, 11, 25, 46, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 30, 70, 25, 25, 12, 22, 18, 25, 45, 70, 23, 25, 12, 43, 11, 34,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 46, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 74, 70, 54, 25, 12, 22, 91, 25, 45, 70, 45, 25, 12, 43, 11, 34,
            10, 64, 12, 97, 71, 25, 12, 12, 22, 81, 25, 34, 70, 90, 25, 12, 43, 11, 34,
            89, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 54, 12, 25, 12, 43, 11, 38,
            13, 64, 12, 30, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            16, 64, 80, 30, 70, 25, 25, 12, 24, 17, 25, 45, 70, 90, 25, 12, 43, 11, 98,
            13, 64, 12, 30, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 30, 70, 25, 25, 12, 22, 11, 25, 45, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 30, 70, 25, 25, 12, 22, 18, 25, 45, 70, 23, 25, 12, 43, 11, 34,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 13, 70, 25, 25, 12, 22, 11, 25, 64, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 23, 70, 54, 25, 12, 22, 91, 25, 86, 70, 45, 25, 12, 43, 11, 34,
            23, 64, 80, 25, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 24, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 30, 70, 54, 25, 12, 22, 91, 25, 45, 70, 45, 25, 12, 43, 11, 34,
            10, 64, 12, 30, 71, 25, 12, 12, 22, 81, 25, 34, 70, 90, 25, 12, 43, 11, 34,
            89, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 54, 12, 25, 12, 43, 11, 38,
            13, 64, 12, 48, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            16, 64, 80, 80, 70, 25, 25, 12, 24, 17, 25, 86, 70, 90, 25, 12, 43, 11, 98,
            13, 64, 12, 46, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 30, 70, 25, 25, 12, 22, 11, 25, 45, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 34, 70, 25, 25, 12, 22, 18, 25, 68, 70, 23, 25, 12, 43, 11, 34,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 45, 70, 54, 25, 12, 22, 91, 25, 45, 70, 45, 25, 12, 43, 11, 34,
            94, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 30, 70, 54, 25, 12, 22, 91, 25, 45, 70, 45, 25, 12, 43, 11, 34,
            10, 64, 12, 47, 71, 25, 12, 12, 22, 81, 25, 57, 70, 90, 25, 12, 43, 11, 34,
            89, 64, 80, 80, 70, 25, 25, 12, 22, 11, 25, 45, 54, 12, 25, 12, 43, 11, 38,
            13, 64, 12, 30, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            16, 64, 80, 30, 70, 25, 25, 12, 24, 17, 25, 45, 70, 90, 25, 12, 43, 11, 98,
            13, 64, 12, 48, 34, 25, 25, 12, 22, 11, 25, 45, 77, 56, 25, 12, 43, 11, 65,
            10, 64, 98, 86, 70, 25, 25, 12, 22, 11, 25, 45, 47, 90, 25, 12, 43, 11, 34,
            12, 64, 83, 23, 70, 25, 25, 12, 22, 18, 25, 86, 70, 23, 25, 12, 43, 11, 34,
            23, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 95, 25, 12, 43, 11, 34,
            94, 64, 80, 30, 70, 25, 25, 12, 22, 11, 25, 45, 70, 89, 25, 12, 43, 11, 34,
            12, 64, 66, 10, 70, 54, 25, 12, 22, 91, 25, 45, 70, 45, 25, 12, 43, 11, 34};

        private string simpleText1 = "Lorem Ip";

        private string simpleText2 = "Lorem Ip";

        private string complexText1 = "here are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation bs H. Rackham.";

        private string complexText2 = "here are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation b H. Rackham.";

        [Benchmark]
        public int AccessingArrayIndex_SimpleInput() => BigONotation.AccessingArrayIndex(simpleInput, 5);

        [Benchmark]
        public int AccessingArrayIndex_ComplexInput() => BigONotation.AccessingArrayIndex(complexInput, 56);

        [Benchmark]
        public bool IsEqual_SimpleInput() => simpleText1.IsEqual(simpleText2);

        [Benchmark]
        public bool IsEqual_ComplexInput() => complexText1.IsEqual(complexText2);
    }
}
