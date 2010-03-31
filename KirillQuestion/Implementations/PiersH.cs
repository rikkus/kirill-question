using System;
using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class PiersH : InsertSpacesFixture
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            // check for null
            if (input == null)
                throw new ArgumentNullException("input");

            var cch = input.Length;

            // simple boundary condition, helps later
            if (cch < 4)
                return input;

            // pre-allocate space
            var sb = new StringBuilder(cch * 3 / 2 + 1); // rik: With fix given later.

            // handle boundary condition later, instead of in loop
            cch -= 3;

            var ich = 0;

            while (ich < cch)
            {
                var ch = input[ich++];

                sb.Append(ch);

                // check for double newlines, won't overflow
                if (ch == '\r' && input[ich] == '\n' && input[ich + 1] == '\r' && input[ich + 2] == '\n')
                {
                    sb.Append("\n ");
                    ich++;
                }
            }

            // copy the remaining characters
            sb.Append(input, ich, input.Length - ich);

            return sb.ToString();
        }
    }
}