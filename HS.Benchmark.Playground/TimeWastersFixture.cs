using NUnit.Framework;

namespace HS.Benchmark.Playground
{
    [TestFixture]
    public class TimeWastersFixture
    {
        [Test]
        public void NaiveReturnsCorrectResult()
        {
            Assert.AreEqual(new[] {1, 2, 42}, TimeWasters.NaiveParse("1 2 42"));
        }

        [Test]
        public void SubStringByIndexParseReturnsCorrectResult()
        {
            Assert.AreEqual(new[] {1, 2, 42}, TimeWasters.SubStringByIndexParse("1 2 42"));
        }

        [Test]
        public void SubStringByIndexPreSizedListParseReturnsCorrectResult()
        {
            Assert.AreEqual(new[] {1, 2, 42}, TimeWasters.SubStringByIndexPreSizedListParse("1 2 42"));
        }

        [Test]
        public void RegExParseReturnsCorrectResult()
        {
            Assert.AreEqual(new[] {1, 2, 42}, TimeWasters.RegExParse("1 2 42"));
        }
    }
}
