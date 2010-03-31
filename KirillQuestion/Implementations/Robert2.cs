using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Robert2 : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return input.Replace("\r\n\r\n", "\r\n \r\n").Replace("\r\n\r\n", "\r\n \r\n");
        }
    }
}