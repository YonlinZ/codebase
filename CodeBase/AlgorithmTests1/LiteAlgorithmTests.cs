using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Tests
{
    [TestClass()]
    public class LiteAlgorithmTests
    {
        [TestMethod()]
        public void FTest()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "e");
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void FTest2()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC");
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void FTest3()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC/DE");
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void FTest4()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC/DEy");
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void FTest5()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC-DE");
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void FTest6()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC-DEy");
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void FTest7()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC/DE-FG");
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void FTest8()
        {
            var actual = LiteAlgorithm.F("ABCDEFG", "ABC/DE-YY");
            Assert.AreEqual(true, actual);
        }



    }
}