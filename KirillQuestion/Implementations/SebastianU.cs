using System;
using System.Linq;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class SebastianU : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return string.Join(Environment.NewLine,
                               input.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Select(
                                   s => s == "" ? " " : s)
                                   .ToArray()); // rik: Took liberty to add ToArray as I'm not on 4.0.
        }
    }
}