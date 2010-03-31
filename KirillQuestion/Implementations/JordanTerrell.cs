using System.Text.RegularExpressions;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class JordanTerrell : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return Regex.Replace(input, @"(\r\n)(?=\r\n)", "$1 ");
        }
    }
}