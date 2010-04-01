using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Fholm : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return FS.fholm.split(input);
        }
    }
}
