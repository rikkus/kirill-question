using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class Jdecuyper : InsertSpacesFixture
    {
        private const char CARRIAGE_RETURN = '\r';
        private const char NEW_LINE = '\n';

        public override string InsertSpaceBetweenCrLfs(string input)
        {
            var textResult = "";

            var caFromText = input.ToCharArray();

            for (var i = 0; i < caFromText.Length; ++i)
            {
                textResult += caFromText[i];

                if (caFromText[i] == CARRIAGE_RETURN)
                {
                    // check if not reaching the end of the array

                    if (i + 3 < caFromText.Length)
                    {
                        if (caFromText[i + 1] == NEW_LINE
                            && caFromText[i + 2] == CARRIAGE_RETURN
                            && caFromText[i + 3] == NEW_LINE)
                        {
                            // two consecutive breaks where detected
                            textResult += "\n ";

                            // jump to the next break
                            ++i;
                        }
                    }
                }
            }
            return input.Replace("\r\n\r\n", "\r\n \r\n");
        }
    }
}