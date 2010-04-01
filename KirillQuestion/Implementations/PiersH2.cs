using System;
using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class PiersH2 : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            // check for null
            if (input == null)

                throw new ArgumentNullException("input");

            int cch = input.Length;

            // simple boundary condition, helps later
            if (cch < 4)
                return input;

            // pre-allocate space
            var sb = new StringBuilder(cch * 3 / 2 + 1);

            // handle boundary condtion later, instead of in loop
            cch -= 3;

            int ichStart = 0;    // the start of the current span
            int ichEnd = 0;    // the end of the current span

            while (ichEnd < cch)
            {
                int ch = input[ichEnd++];

                // check for double newlines, won't overflow
                if (ch == '\r' && input[ichEnd] == '\n' && input[ichEnd + 1] == '\r' && input[ichEnd + 2] == '\n')
                {
                    // copy the previous span
                    sb.Append(input, ichStart, ichEnd - ichStart);

                    // add a space
                    sb.Append(' ');

                    // start the new span
                    ichStart = ++ichEnd;
                }
            }

            // copy the remaining characters
            sb.Append(input, ichStart, cch - ichStart + 3);

            return sb.ToString();
        }
    }
}