using Algorithms_Data_Structures.Algorithms.reverserinteger;
using Xunit;

namespace tests.Algorithms;

public class ReverserIntegerTest
{
    [Theory]
    [InlineData(123, "321")]
    [InlineData(1230, "321")]
    [InlineData(12300, "321")]
    [InlineData(123000, "321")]
    [InlineData(12030, "3021")]
    [InlineData(10000, "1")]
    [InlineData(10110, "1101")]
    [InlineData(101100, "1101")]
    public void MustReversesAInteger(int input, string expectedOutput)
    {
        string result = ReverserInteger.Reverse(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(123, "321")]
    [InlineData(1230, "321")]
    [InlineData(12300, "321")]
    [InlineData(123000, "321")]
    [InlineData(12030, "3021")]
    [InlineData(10000, "1")]
    [InlineData(10110, "1101")]
    [InlineData(101100, "1101")]
    public void MustReversesAInteger_2(int input, string expectedOutput)
    {
        string result = ReverserInteger.Reverse2(input);
        Assert.Equal(expectedOutput, result);
    }
}
