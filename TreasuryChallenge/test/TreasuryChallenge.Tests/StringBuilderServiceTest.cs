using System.Text;
using TreasuryChallenge.Services;
using Xunit;

namespace TreasuryChallenge
{
    public class StringBuilderServiceTest
    {
        [Fact]
        public void MustNotCreateDuplicateCodes()
        {
            StringBuilderService stringBuilderService = new StringBuilderService();
            string valueDuplicated1 = "ABCDE";
            string valueDuplicated2 = "ABCDT";
            string[] expectedValues = new string[] { valueDuplicated1, valueDuplicated2, "TBCDE", "ZBCDT" };
            string[] values = new string[] { valueDuplicated1, valueDuplicated1, valueDuplicated2, "TBCDE", valueDuplicated2, "ZBCDT" };

            foreach (string value in values) {
                stringBuilderService.Append(value);
            }

            StringBuilder stringBuilder  = stringBuilderService.GetStringContent();

            string[] result = stringBuilder.ToString().Trim().Split("\r\n");

            Assert.Equal(expectedValues, result);
        }
    }
}
