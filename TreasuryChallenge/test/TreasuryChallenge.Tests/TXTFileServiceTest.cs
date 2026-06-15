using System.Text;
using TreasuryChallenge.controller;
using TreasuryChallenge.Interface;
using TreasuryChallenge.Services;
using Xunit;

namespace TreasuryChallenge
{
    public class TXTFileServiceTest
    {
        [Fact]
        public void MustWriteCodeInFileSuccessfully()
        {
            try
            {
                StringBuilder stringContent = new StringBuilder();
                IFileService fileService = new TXTFileService();
                 IContentService contentService = new ContentService(7,1000);
                WriteFileController  writeFile = new WriteFileController(fileService, contentService);
                writeFile.WriteCodeInFile();

                Assert.True(true);
            }
            catch {
                Assert.True(false);
            }
        }
    }
}
