using System;
using System.Linq;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Banko : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return
                input
                    .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                    .Select(x => x.Length == 0 ? " " : x)
                    .Aggregate((a, x) => a + Environment.NewLine + x);
        }
    }
}