using System.Text;

namespace TreasuryChallenge.Interface
{
    public interface IStringBuilderService
    {
        public bool Append(string value);
        public StringBuilder GetStringContent();
    }
}
