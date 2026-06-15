using System.IO;
using System.Text;
using TreasuryChallenge.Common;
using TreasuryChallenge.Interface;

namespace TreasuryChallenge.Services
{
    public class TXTFileService : IFileService
    {
        public void WriteFile(string fileName, StringBuilder stringContent)
        {
            string fileNameWithExtension = fileName + Constants.TXT_EXTENSION;

            using (StreamWriter write = new StreamWriter(fileNameWithExtension))
            {
                write.Write(stringContent);
            };
        }
    }
}