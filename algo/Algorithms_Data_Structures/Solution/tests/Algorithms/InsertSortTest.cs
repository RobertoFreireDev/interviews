using Algorithms_Data_Structures.Algorithms.Sort;
using tests.Extension;
using Xunit;

namespace tests.Algorithms
{
    public class InsertSortTest
    {
        [Theory]
        [InlineData("64, 25, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 25, 64")]
        [InlineData("64,34,57,25,1,25,7,25,12,22,11,70,45,64,25,12,22,11,33,66,53,12,15,79,56,25", "1, 7, 11, 11, 12, 12, 12, 15, 22, 22, 25, 25, 25, 25, 25, 33, 34, 45, 53, 56, 57, 64, 64, 66, 70, 79")]
        [InlineData("20,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,19", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20")]
        [InlineData("64, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 64")]
        [InlineData("64, 26, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 26, 64")]
        [InlineData("64, 26, 12, 22, 11, 25", "11, 12, 22, 25, 26, 64")]
        [InlineData("1, 25, 7, 25, 12, 22, 11, 70", "1, 7, 11, 12, 22, 25, 25, 70")]
        [InlineData("11, 5", "5, 11")]
        [InlineData("3", "3")]
        [InlineData("3, 5", "3, 5")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        [InlineData("3, 2, 1", "1, 2, 3")]
        [InlineData("3, 0, 3", "0, 3, 3")]
        public void Sort(string array, string expectedOutput)
        {
            var result = InsertSort.Sort(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }

        [Theory]
        [InlineData("64, 25, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 25, 64")]
        [InlineData("64,34,57,25,1,25,7,25,12,22,11,70,45,64,25,12,22,11,33,66,53,12,15,79,56,25", "1, 7, 11, 11, 12, 12, 12, 15, 22, 22, 25, 25, 25, 25, 25, 33, 34, 45, 53, 56, 57, 64, 64, 66, 70, 79")]
        [InlineData("20,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,19", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20")]
        [InlineData("64, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 64")]
        [InlineData("64, 26, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 26, 64")]
        [InlineData("64, 26, 12, 22, 11, 25", "11, 12, 22, 25, 26, 64")]
        [InlineData("1, 25, 7, 25, 12, 22, 11, 70", "1, 7, 11, 12, 22, 25, 25, 70")]
        [InlineData("11, 5", "5, 11")]
        [InlineData("3", "3")]
        [InlineData("3, 5", "3, 5")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        [InlineData("3, 2, 1", "1, 2, 3")]
        [InlineData("3, 0, 3", "0, 3, 3")]
        public void Sort_Solution2(string array, string expectedOutput)
        {
            var result = InsertSort.Sort_Solution2(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }
    }
}
