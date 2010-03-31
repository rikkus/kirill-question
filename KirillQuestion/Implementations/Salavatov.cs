using System;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Salavatov : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var sa = input.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            input = string.Empty;

            foreach (var ss in sa)
                input += (ss == string.Empty ? " " : ss) + Environment.NewLine;

            return input;
        }
    }
}