using System;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class JeffreyNelson : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var origNewlines = Environment.NewLine + Environment.NewLine;
            var newNewlines = Environment.NewLine + "-" + Environment.NewLine;

            var offset = Environment.NewLine.Length + 1;

            var startIndex = 0;

            var idx = input.IndexOf(origNewlines, startIndex);

            while (idx >= 0)
            {
                input = input.Replace(origNewlines, newNewlines);
                startIndex += offset;
                idx = input.IndexOf(origNewlines, startIndex);
            }

            return input;
        }
    }
}