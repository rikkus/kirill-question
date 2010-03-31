using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Dbkk : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            while (input.Contains("\r\n\r\n"))
                input = input.Replace("\r\n\r\n", "\r\n \r\n");

            return input;
        }
    }
}