using System.Text;

namespace TreasuryChallenge.Interface
{
    public interface IContentService
    {
        public StringBuilder Generate();
        public int GetNumberOfLines();
    }
}
