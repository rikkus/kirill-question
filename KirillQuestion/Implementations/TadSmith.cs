using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class TadSmith : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            input.Replace("\r\n\r\n", "\r\n \r\n");

            input.Replace("\r\n\r\n", "\r\n \r\n");

            return input;
        }
    }
}