using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class KooKiz : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var startIndex = 0;

            var sb = new StringBuilder(input.Length * 2);

            while (true)
            {
                var index = input.IndexOf("\r\n", startIndex);

                if (index == -1)
                {
                    break;
                }

                var length = index - startIndex;

                sb.Append(input.Substring(startIndex, length));

                if (length == 1)
                {
                    sb.Append("-");
                }

                startIndex = index + 1;
            }

            return sb.ToString();
        }
    }
}