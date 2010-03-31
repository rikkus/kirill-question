using System.IO;
using System.Text;
using NUnit.Framework;

namespace KirillQuestion.Implementations
{
    [TestFixture]
    public class HuseyinTufekcileri : InsertSpacesFixture // rik: Apologies for mangling your name
    {
        public override string InsertSpaceBetweenCrLfs(string _input)
        {
            var input = new StringReader(_input);

            var output = new StringBuilder();

            string line = null;

            while ((line = input.ReadLine()) != null)

                output.AppendLine(line.Equals(string.Empty) ? " " : line);

            return output.ToString();
        }
    }
}