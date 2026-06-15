using System.Text;

namespace TreasuryChallenge.Interface
{
    public interface IFileService
    {
        public void WriteFile(string fileName, StringBuilder stringContent);
    }
}