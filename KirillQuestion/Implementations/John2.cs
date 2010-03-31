using System.Text.RegularExpressions;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class John2 : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            while (Regex.Match(input, "(\r\n)(\\1)").Success)
            {
                input = Regex.Replace(input, "(\r\n)(\\1)", "$1-$1");
            }

            return input;
        }
    }
}