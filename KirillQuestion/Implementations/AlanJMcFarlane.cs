using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class AlanJMcFarlane : InsertSpacesFixture
    {
        public string InsertBetweenTwoMatches(string input, string match, string insert)
        {
            var matchPos = 0;

            var lastWasMatch = false;

            var initialCapacity = input.Length;

            var bldr = new StringBuilder(initialCapacity);

            foreach (var cur in input)
            {
                Debug.Assert(matchPos < match.Length, "Match complete, should have been detected last loop!");

                // Note this (and below) comparison is ordinal, and thus is not good for all scripts...

                if (cur == match[matchPos])
                {
                    ++matchPos;

                    // Don't write out.
                }
                else
                {
                    // Failed the match, reset, write out the ones we've stripped.

                    bldr.Append(match.Substring(0, matchPos));

                    lastWasMatch = false;

                    matchPos = 0;

                    // Need to check the current char again the reset match!

                    if (cur == match[matchPos])
                    {
                        ++matchPos;

                        // Don't write out.
                    }
                    else
                    {
                        bldr.Append(cur);
                    }
                }

                //

                if (matchPos == match.Length)
                {
                    matchPos = 0;

                    if (!lastWasMatch)
                    {
                        lastWasMatch = true;

                        bldr.Append(match);
                    }
                    else
                    {
                        bldr.Append(insert);

                        bldr.Append(match);

                        Debug.Assert(lastWasMatch, "As we insert between every pair.");
                    }
                }
            } //for

            return bldr.ToString();
        }

        public override string InsertSpaceBetweenCrLfs(string input)
        {
            // rik: Altered somewhat from Alan's, hopefully as he'd like it...
            return InsertBetweenTwoMatches(input, "\r\n", " ");
        }
    }
}