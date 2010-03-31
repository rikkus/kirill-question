using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class KooKiz2 : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var result = input;

            var tmp = string.Empty;

            while (result.Length != tmp.Length)
            {
                tmp = result;
                result = tmp.Replace("\r\n\r\n", "\r\n \r\n"); // rik: Altered to add space, not dash.
            }

            return result;
        }
    }
}