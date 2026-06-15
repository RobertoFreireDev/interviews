using System;
using TreasuryChallenge.Common;
using TreasuryChallenge.Interface;

namespace TreasuryChallenge.controller
{
    public class WriteFileController 
    {
        public IFileService FileService { get; private set; }
        public IContentService ContentService { get; private set; }

        public WriteFileController(
            IFileService fileService,
            IContentService contentService)
        {
            FileService = fileService;
            ContentService = contentService;
        }
        public void WriteCodeInFile()
        {
            try
            {
                var content = ContentService.Generate();
                FileService.WriteFile(Constants.FILE_NAME, content);
                Console.WriteLine(string.Format(Constants.FILE_WITH_0_LINES_WAS_GENERATED, ContentService.GetNumberOfLines()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ERROR_TO_GENERATE_FILE + ex.Message);
            }
        }
    }
}
