using System.Text.RegularExpressions;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class John : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return Regex.Replace(input, "(\r\n)(\\1)", "$1 $2");
        }
    }
}