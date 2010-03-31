using System.Text.RegularExpressions;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class John3 : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            if (!Regex.Match(input, "(\r\n)(\\1)").Success)
            {
                return input;
            }
            else
            {
                input = Regex.Replace(input, "(\r\n)(\\1)", "$1-$1");
                return InsertSpaceBetweenCrLfs(input);
            }
        }
    }
}