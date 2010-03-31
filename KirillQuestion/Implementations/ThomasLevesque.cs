using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class ThomasLevesque : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var sb = new StringBuilder();

            var prevCrLf = false;

            var prev = '\0';

            foreach (var c in input)
            {
                if (c == '\n' && prev == '\r')
                {
                    if (prevCrLf) sb.Append(' ');
                    prevCrLf = true;
                }
                else if (c != '\r')
                {
                    prevCrLf = false;
                }

                sb.Append(c);
                prev = c;
            }

            return sb.ToString();
        }
    }
}