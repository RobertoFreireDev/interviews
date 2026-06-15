using Algorithms_Data_Structures.BigONotation;
using tests.Extension;
using Xunit;

namespace tests.Algorithms
{
    public class BigONotationTests
    {
        [Theory]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting", "Lorem Ipsum is simply dummy text of the printing and typestting", false)]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting", "Lorem Ipsum is simply dummy text of the printing and typesetting", true)]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting", "Lorem Ipsum is simply dummy text of the printing and typesett1ng", false)]
        [InlineData("A", "A", true)]
        [InlineData("", "", true)]
        [InlineData("", "B", false)]
        [InlineData("CSa", "B", false)]
        public void Sort(string text1, string text2, bool expectedOutput)
        {
            var result = text1.IsEqual(text2);

            Assert.Equal(expectedOutput, result);
        }


        [Theory]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", -2, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", -20, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 0, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 1, 0)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 2, 1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 3, 3)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 4, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 5, 4)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 6, 5)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 7, 6)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 8, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 9, 8)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 10, 9)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 11, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 12, 10)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 13, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 14, -1)]
        [InlineData("1,2,2,3,5,6,7,7,9,10,12,12", 100, -1)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", -1, -1)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 0, 0)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 1, -1)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 2, 1)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 6, 5)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 10, 6)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 12, 11)]
        [InlineData("0,2,2,2,2,6,10,10,10,10,10,12", 15, -1)]
        public void BinarySearchMain(string numbers, int value, int expectedOutput)
        {
            var result = BigONotation.BinarySearchMain(numbers.CreateIntArray(), value);

            Assert.Equal(expectedOutput, result);
        }
    }
}
