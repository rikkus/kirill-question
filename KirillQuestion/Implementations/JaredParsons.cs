using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class JaredParsons : InsertSpacesFixture 
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return FS.JaredParsons.InsertSpaceBetweenCrLfs(input);
        }
    }
}


