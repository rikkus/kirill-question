using NUnit.Framework;

namespace KirillQuestion
{
    public abstract class InsertSpacesFixture : IInsertSpaces
    {
        #region IInsertSpaces Members

        public abstract string InsertSpaceBetweenCrLfs(string input);

        #endregion

        [Test]
        public void EmptyStringUnaltered()
        {
            Assert.AreEqual(string.Empty, InsertSpaceBetweenCrLfs(string.Empty));
        }

        [Test]
        public void SingleCrLfUnaltered()
        {
            Assert.AreEqual("\r\n", InsertSpaceBetweenCrLfs("\r\n"));
        }

        [Test]
        public void TwoCrLfsOnlyAreSeparated()
        {
            Assert.AreEqual("\r\n \r\n", InsertSpaceBetweenCrLfs("\r\n\r\n"));
        }

        [Test]
        public void ThreeCrLfsAreSeparated()
        {
            Assert.AreEqual("\r\n \r\n \r\n", InsertSpaceBetweenCrLfs("\r\n\r\n\r\n"));
        }

        [Test]
        public void TwoCrLfsAlreadySeparatedUnaltered()
        {
            Assert.AreEqual("\r\n \r\n", InsertSpaceBetweenCrLfs("\r\n \r\n"));
        }

        [Test]
        public void TwoCrLfsBeforeOtherStuffAreSeparatedAndOtherStuffUnaltered()
        {
            Assert.AreEqual("\r\n \r\nhello", InsertSpaceBetweenCrLfs("\r\n\r\nhello"));
        }

        [Test]
        public void TwoCrLfsAterOtherStuffAreSeparatedAndOtherStuffUnaltered()
        {
            Assert.AreEqual("hello\r\n \r\n", InsertSpaceBetweenCrLfs("hello\r\n\r\n"));
        }

        [Test]
        public void CrCrLfLfUnaltered()
        {
            Assert.AreEqual("\r\r\n\n", InsertSpaceBetweenCrLfs("\r\r\n\n"));
        }

        [Test]
        public void LfCrUnaltered()
        {
            Assert.AreEqual("\n\r", InsertSpaceBetweenCrLfs("\n\r"));
        }

        [Test]
        public void WeirdUnicodeDoesNotCauseFail()
        {
            Assert.AreEqual("۩", InsertSpaceBetweenCrLfs("۩"));
        }
    }
}