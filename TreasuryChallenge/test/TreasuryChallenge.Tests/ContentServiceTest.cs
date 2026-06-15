using TreasuryChallenge.Interface;
using TreasuryChallenge.Services;
using Xunit;

namespace TreasuryChallenge
{
    public class ContentServiceTest
    {
        [Fact]
        public void MustGenerateStringBuilderWithCorrectLength()
        {
            int length = 10;
            int lengthCode = 7;
            IContentService contentService = new ContentService(lengthCode, length);

            string[] result = contentService.Generate().ToString().Trim().Split("\r\n");

            Assert.Equal(length, result.Length);
        } 
    }
}
