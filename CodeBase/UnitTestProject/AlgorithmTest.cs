using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace UnitTestProject
{
    [TestClass]
    public class AlgorithmTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "test";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                //SortAlgorithm.test();
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }



        }
    }
}
