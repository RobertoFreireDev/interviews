using Algorithms_Data_Structures.Algorithms.Sort;
using FluentAssertions;
using tests.Extension;
using Xunit;

namespace tests.Algorithms
{
    public class SelectionSortTest
    {
        [Fact]
        public void SortItems()
        {
            var items = new Item[]
            {
                new Item { Value = 64, Index = 4},
                new Item { Value = 25, Index = 3},
                new Item { Value = 25, Index = 2},
                new Item { Value = 12, Index = 5},
                new Item { Value = 22, Index = 1},
                new Item { Value = 11, Index = 6},
                new Item { Value = 25, Index = 0}
            };

            var expectedResult = new Item[]
            {
                new Item { Value = 11, Index = 6},
                new Item { Value = 12, Index = 5},
                new Item { Value = 22, Index = 1},
                new Item { Value = 25, Index = 3},
                new Item { Value = 25, Index = 2},
                new Item { Value = 25, Index = 0},
                new Item { Value = 64, Index = 4}
            };

            var result = SelectionSort.Sort(items);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("64, 25, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 25, 64")]
        [InlineData("64, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 64")]
        [InlineData("1, 25, 7, 25, 12, 22, 11, 70", "1, 7, 11, 12, 22, 25, 25, 70")]
        [InlineData("11, 5","5, 11")]
        [InlineData("3", "3")]
        [InlineData("3, 5", "3, 5")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        [InlineData("3, 2, 1", "1, 2, 3")]
        [InlineData("3, 0, 3", "0, 3, 3")]
        public void Sort(string array, string expectedOutput)
        {
            var result = SelectionSort.Sort(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }

        [Theory]
        [InlineData("64, 25, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 25, 64")]
        [InlineData("64, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 64")]
        [InlineData("1, 25, 7, 25, 12, 22, 11, 70", "1, 7, 11, 12, 22, 25, 25, 70")]
        [InlineData("11, 5", "5, 11")]
        [InlineData("3", "3")]
        [InlineData("3, 5", "3, 5")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        [InlineData("3, 2, 1", "1, 2, 3")]
        [InlineData("3, 0, 3", "0, 3, 3")]
        public void Sort_Solution2(string array, string expectedOutput)
        {
            var result = SelectionSort.Sort_Solution2(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }

        [Theory]
        [InlineData("64, 25, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 25, 64")]
        [InlineData("64, 25, 12, 22, 11, 25", "11, 12, 22, 25, 25, 64")]
        [InlineData("1, 25, 7, 25, 12, 22, 11, 70", "1, 7, 11, 12, 22, 25, 25, 70")]
        [InlineData("11, 5", "5, 11")]
        [InlineData("3", "3")]
        [InlineData("3, 5", "3, 5")]
        [InlineData("1, 2, 3", "1, 2, 3")]
        [InlineData("3, 2, 1", "1, 2, 3")]
        [InlineData("3, 0, 3", "0, 3, 3")]
        public void Sort_Solution3(string array, string expectedOutput)
        {
            var result = SelectionSort.Sort_Solution3(array.CreateIntArray());

            Assert.Equal(expectedOutput, result.CreateString());
        }
    }
}
