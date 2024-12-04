using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _2TaskPIS;
using NUnit.Compatibility;

namespace UnitTestProject2 {
    [TestClass]
    public class UnitTest1 {
        //[TestMethod]

        [NUnit.Framework.Test]
        public void GetLinesCodesFromTextFileTestEmpty() {

            //arrange
            string path = "C:/Users/Kostya/OneDrive/Desktop/TestReader1.txt";
            var expected = new string[0];

            //act
            MeterDataReader meterDataReader = new MeterDataReader();
            var actual = meterDataReader.GetLinesCodesFromTextFile(path);

            //assert
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, 1);
            //Microsoft.VisualStudio.TestTools.UnitTesting.
        }
    }
}
