using System.Text.RegularExpressions;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class JordanTerrellCached : InsertSpacesFixture
    {
        static readonly Regex Expression = new Regex(@"(\r\n)(?=\r\n)", RegexOptions.Compiled);

        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return Expression.Replace(input, "$1 ");
        }
    }
}