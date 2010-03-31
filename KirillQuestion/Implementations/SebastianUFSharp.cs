using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class SebastianUFSharp : InsertSpacesFixture 
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return FS.SebastianU.InsertSpaceBetweenCrLfs(input);
        }
    }
}


