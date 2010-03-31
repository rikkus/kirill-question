using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Ram : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return input.Replace("\n\r", "\n \r");
        }
    }
}